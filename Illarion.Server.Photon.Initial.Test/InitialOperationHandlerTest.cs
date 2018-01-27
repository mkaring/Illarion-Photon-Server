using System;
using System.Collections.Generic;
using System.Globalization;
using Illarion.Net.Common;
using Illarion.Net.Common.Operations.Initial;
using Microsoft.Extensions.DependencyInjection;
using Photon.SocketServer;
using Photon.SocketServer.UnitTesting;
using Xunit;

namespace Illarion.Server.Photon
{
  public sealed class InitialOperationHandlerTest
  {
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
        Assert.Equal((int)SetCultureOperationReturnCode.Success, response.ReturnCode);

        Assert.Equal(application.LastCreatedPeer.Culture, CultureInfo.GetCultureInfo(cultureName));
      }
      finally
      {
        applicationProxy.Stop();
      }
    }
  }
}
