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
      PhotonApplicationProxy applicationProxy = StartTestApplication();
      var application = (TestApplication)applicationProxy.Application;
      try
      {
        var testClient = new UnitTestClient();
        testClient.Connect(applicationProxy);

        AssertInitialConnection(applicationProxy, testClient);

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
        Assert.IsAssignableFrom<IInitialOperationHandler>(application.LastCreatedPeer.CurrentOperationHandler);
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
      var accountOperationHandler = new TestAccountOperationHandler();

      IServiceProvider serviceProvider = new ServiceCollection().
        AddIllarionTestPersistanceContext().
        AddSingleton<IAccountOperationHandler>(accountOperationHandler).
        BuildServiceProvider();

      CreateTestAccount(serviceProvider);

      PhotonApplicationProxy applicationProxy = StartTestApplication(serviceProvider);
      var application = (TestApplication)applicationProxy.Application;
      try
      {
        var testClient = new UnitTestClient();
        testClient.Connect(applicationProxy);

        AssertInitialConnection(applicationProxy, testClient);

        Assert.Equal(SendResult.Ok, testClient.InitializeEncyption(10000));

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

        Assert.Same(accountOperationHandler, application.LastCreatedPeer.CurrentOperationHandler);
      }
      finally
      {
        applicationProxy.Stop();
      }
    }

    [Trait("Category", "Networking")]
    [Fact]
    public static void ConnectedLoginAccountNotEncryptedTest()
    {
      PhotonApplicationProxy applicationProxy = StartTestApplication();
      var application = (TestApplication)applicationProxy.Application;
      try
      {
        var testClient = new UnitTestClient();
        testClient.Connect(applicationProxy);

        AssertInitialConnection(applicationProxy, testClient);

        SendResult result = testClient.SendOperationRequest(
                  new OperationRequest(
                    (byte)InitialOperationCode.LoginAccount,
                    new Dictionary<byte, object>() {
              { (byte) LoginAccountOperationParameterCode.AccountName, "TestAccount" },
              { (byte) LoginAccountOperationParameterCode.Password, "test1234" },
                    }));
        Assert.Equal(SendResult.Ok, result);

        OperationResponse response = testClient.WaitForOperationResponse(100);
        Assert.NotNull(response);
        Assert.Equal((byte)InitialOperationCode.LoginAccount, response.OperationCode);
        Assert.Equal((int)LoginAccountOperationReturnCode.NotEncrypted, response.ReturnCode);

        Assert.Null(application.LastCreatedPeer.Account);
        Assert.IsAssignableFrom<IInitialOperationHandler>(application.LastCreatedPeer.CurrentOperationHandler);
      }
      finally
      {
        applicationProxy.Stop();
      }
    }

    [Trait("Category", "Networking")]
    [Fact]
    public static void ConnectedLoginAccountWrongUserNameTest()
    {

      IServiceProvider serviceProvider = new ServiceCollection().
        AddIllarionTestPersistanceContext().
        BuildServiceProvider();

      CreateTestAccount(serviceProvider);

      PhotonApplicationProxy applicationProxy = StartTestApplication(serviceProvider);
      var application = (TestApplication)applicationProxy.Application;
      try
      {
        var testClient = new UnitTestClient();
        testClient.Connect(applicationProxy);

        AssertInitialConnection(applicationProxy, testClient);

        Assert.Equal(SendResult.Ok, testClient.InitializeEncyption(10000));

        SendResult result = testClient.SendOperationRequest(
          new OperationRequest(
            (byte)InitialOperationCode.LoginAccount,
            new Dictionary<byte, object>() {
              { (byte) LoginAccountOperationParameterCode.AccountName, "TestAccount2" },
              { (byte) LoginAccountOperationParameterCode.Password, "test1234" },
            }), encrypted: true);
        Assert.Equal(SendResult.Ok, result);

        OperationResponse response = testClient.WaitForOperationResponse(10000);
        Assert.NotNull(response);
        Assert.Equal((byte)InitialOperationCode.LoginAccount, response.OperationCode);
        Assert.Equal((int)LoginAccountOperationReturnCode.WrongNameOrPassword, response.ReturnCode);

        Assert.Null(application.LastCreatedPeer.Account);
        Assert.IsAssignableFrom<IInitialOperationHandler>(application.LastCreatedPeer.CurrentOperationHandler);
      }
      finally
      {
        applicationProxy.Stop();
      }
    }

    [Trait("Category", "Networking")]
    [Fact]
    public static void ConnectedLoginAccountWrongPasswordTest()
    {

      IServiceProvider serviceProvider = new ServiceCollection().
        AddIllarionTestPersistanceContext().
        BuildServiceProvider();

      CreateTestAccount(serviceProvider);

      PhotonApplicationProxy applicationProxy = StartTestApplication(serviceProvider);
      var application = (TestApplication)applicationProxy.Application;
      try
      {
        var testClient = new UnitTestClient();
        testClient.Connect(applicationProxy);

        AssertInitialConnection(applicationProxy, testClient);

        Assert.Equal(SendResult.Ok, testClient.InitializeEncyption(10000));

        SendResult result = testClient.SendOperationRequest(
          new OperationRequest(
            (byte)InitialOperationCode.LoginAccount,
            new Dictionary<byte, object>() {
              { (byte) LoginAccountOperationParameterCode.AccountName, "TestAccount" },
              { (byte) LoginAccountOperationParameterCode.Password, "test123456" },
            }), encrypted: true);
        Assert.Equal(SendResult.Ok, result);

        OperationResponse response = testClient.WaitForOperationResponse(10000);
        Assert.NotNull(response);
        Assert.Equal((byte)InitialOperationCode.LoginAccount, response.OperationCode);
        Assert.Equal((int)LoginAccountOperationReturnCode.WrongNameOrPassword, response.ReturnCode);

        Assert.Null(application.LastCreatedPeer.Account);
        Assert.IsAssignableFrom<IInitialOperationHandler>(application.LastCreatedPeer.CurrentOperationHandler);
      }
      finally
      {
        applicationProxy.Stop();
      }
    }

    private static void AssertInitialConnection(PhotonApplicationProxy applicationProxy, UnitTestClient testClient)
    {
      var application = (TestApplication)applicationProxy.Application;

      Assert.True(testClient.Connected);
      Assert.Equal(1, applicationProxy.ClientCount);
      Assert.NotNull(application.LastCreatedPeer);
      Assert.IsAssignableFrom<IInitialOperationHandler>(application.LastCreatedPeer.CurrentOperationHandler);
    }

    private static void CreateTestAccount(IServiceProvider serviceProvider)
    {
      IAccountsContext ctx = serviceProvider.GetRequiredService<IAccountsContext>();
      ctx.Accounts.Add(
        new Account("TestAccount")
        {
          EMail = "test@illarion.org",
          Password = PasswordHashing.GetPasswordHash("test1234")
        });
      ctx.SaveChanges();
    }

    private static PhotonApplicationProxy StartTestApplication() =>
      StartTestApplication(new ServiceCollection().BuildServiceProvider());

    private static PhotonApplicationProxy StartTestApplication(IServiceProvider serviceProvider)
    {
      var operationHandler = new InitialOperationHandler(serviceProvider);
      var application = new TestApplication(operationHandler);
      var applicationProxy = new PhotonApplicationProxy(application);
      applicationProxy.Start();

      return applicationProxy;
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
