using System;
using System.Collections.Generic;
using System.Globalization;
using Illarion.Net.Common;
using Illarion.Net.Common.Operations.Initial;
using Illarion.Server.Persistence;
using Illarion.Server.Persistence.Accounts;
using Microsoft.Extensions.DependencyInjection;
using Photon.SocketServer;
using Photon.SocketServer.UnitTesting;
using Xunit;

namespace Illarion.Server.Photon
{
  public sealed class InitialOperationHandlerTest
  {
    [Trait("Category", "Networking")]
    [Theory]
    [InlineData("de"), InlineData("de-DE"), InlineData("en"), InlineData("en-US"), InlineData("en-GB")]
    public static void ConnectedSetCultureTest(string cultureName)
    {
      IServiceProvider serviceProvider = new ServiceCollection().BuildServiceProvider();

      var operationHandler = new InitialOperationHandler(serviceProvider);
      var application = new TestApplication(operationHandler);
      var applicationProxy = new PhotonApplicationProxy(application);
      applicationProxy.Start();
      try
      {
        var testClient = new UnitTestClient();
        testClient.Connect(applicationProxy);

        Assert.True(testClient.Connected);
        Assert.Equal(1, applicationProxy.ClientCount);
        Assert.NotNull(application.LastCreatedPeer);

        SendResult result = testClient.SendOperationRequest(
          new OperationRequest(
            (byte)InitialOperationCode.SetCulture,
            new Dictionary<byte, object>() {
              { (byte) SetCultureOperationParameterCode.CultureName, cultureName },
            }));
        Assert.Equal(SendResult.Ok, result);

        OperationResponse response = testClient.WaitForOperationResponse(100);
        Assert.NotNull(response);
        Assert.Equal((byte)InitialOperationCode.SetCulture, response.OperationCode);
        Assert.Equal((int)SetCultureOperationReturnCode.Success, response.ReturnCode);

        Assert.Equal(application.LastCreatedPeer.Culture, CultureInfo.GetCultureInfo(cultureName));
      }
      finally
      {
        applicationProxy.Stop();
      }
    }

    [Trait("Category", "Networking")]
    [Fact]
    public static void ConnectedLoginAccountTest()
    {
      IServiceProvider serviceProvider = new ServiceCollection().
        AddIllarionTestPersistanceContext().
        AddSingleton<IAccountOperationHandler>(new TestAccountOperationHandler()).
        BuildServiceProvider();
      
      {
        IAccountsContext ctx = serviceProvider.GetRequiredService<IAccountsContext>();
        ctx.Accounts.Add(
          new Account("TestAccount")
          {
            EMail = "test@illarion.org",
            Password = "test1234"
          });
        ctx.SaveChanges();
      }

      using (var hoster = new PhotonApplicationHoster())
      {
        var operationHandler = new InitialOperationHandler(serviceProvider);
        var application = new TestApplication(operationHandler);
        var applicationProxy = new PhotonApplicationProxy(application);
        applicationProxy.Start();

        try
        {
          hoster.AddListenerToApplication(applicationProxy, "0.0.0.0", 12345);
          UnitTestClient testClient = hoster.CreateClient("0.0.0.0", 12345, application.SdkVersion, 42);

          Assert.Equal(SendResult.Ok, testClient.InitializeEncyption(10000));

          Assert.True(testClient.Connected);
          Assert.Equal(1, applicationProxy.ClientCount);
          Assert.NotNull(application.LastCreatedPeer);

          SendResult result = testClient.SendOperationRequest(
            new OperationRequest(
              (byte)InitialOperationCode.LoginAccount,
              new Dictionary<byte, object>() {
              { (byte) LoginAccountOperationParameterCode.AccountName, "TestAccount" },
              { (byte) LoginAccountOperationParameterCode.Password, "test1234" },
              }), encrypted: true);
          Assert.Equal(SendResult.Ok, result);

          OperationResponse response = testClient.WaitForOperationResponse(10000);
          Assert.NotNull(response);
          Assert.Equal((byte)InitialOperationCode.LoginAccount, response.OperationCode);
          Assert.Equal((int)LoginAccountOperationReturnCode.Success, response.ReturnCode);

          Assert.NotNull(application.LastCreatedPeer.Account);
          Assert.Equal("TestAccount", application.LastCreatedPeer.Account.AccountName);
        }
        finally
        {
          applicationProxy.Stop();
        }
      }
    }

    private sealed class TestAccountOperationHandler : IAccountOperationHandler
    {
      public void OnDisconnect(PeerBase peer)
      {
      }

      public OperationResponse OnOperationRequest(PeerBase peer, OperationRequest operationRequest, SendParameters sendParameters) =>
        throw new NotImplementedException();
    }
  }
}
