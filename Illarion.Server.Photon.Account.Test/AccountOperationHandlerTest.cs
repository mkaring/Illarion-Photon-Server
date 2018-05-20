using Illarion.Net.Common;
using Illarion.Net.Common.Operations.Account;
using Illarion.Server.Persistence.Accounts;
using Microsoft.Extensions.DependencyInjection;
using Photon.SocketServer;
using Photon.SocketServer.UnitTesting;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace Illarion.Server.Photon
{
  public class AccountOperationHandlerTest
  {
    private readonly ITestOutputHelper _output;

    public AccountOperationHandlerTest(ITestOutputHelper output) =>
      _output = output ?? throw new ArgumentNullException(nameof(output));

    [Trait("Category", "Networking")]
    [Fact]
    public void CharacterListResponseTest()
    {
      IServiceProvider serviceProvider = new ServiceCollection().
        AddIllarionTestLogging(_output).
        AddIllarionTestPersistanceContext().
        BuildServiceProvider();

      Account account = CreateTestAccount(serviceProvider);

      PhotonApplicationProxy applicationProxy = StartTestApplication(serviceProvider);
      var application = (TestApplication)applicationProxy.Application;
      try
      {
        var testClient = new UnitTestClient();
        testClient.Connect(applicationProxy);

        AssertInitialConnection(applicationProxy, testClient);
        application.LastCreatedPeer.Account = account;

        SendResult result = testClient.SendOperationRequest(
          new OperationRequest(
            (byte)AccountOperationCode.ListCharacters)
          );
        Assert.Equal(SendResult.Ok, result);

        OperationResponse response = testClient.WaitForOperationResponse(1000);
        Assert.NotNull(response);
        Assert.Equal((byte)AccountOperationCode.ListCharacters, response.OperationCode);
        Assert.Equal((int)ListCharactersOperationReturnCode.Success, response.ReturnCode);

        var characterListResponseObj = response.Parameters[(byte)ListCharactersOperationResponseParameterCode.CharacterList];
        Assert.IsAssignableFrom<ICollection>(characterListResponseObj);
        var characterListResponse = (ICollection)characterListResponseObj;
        Assert.Equal(0, characterListResponse.Count);

        Assert.Throws<TimeoutException>(() => testClient.WaitForOperationResponse(1000));
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
      Assert.IsAssignableFrom<IAccountOperationHandler>(application.LastCreatedPeer.CurrentOperationHandler);
    }

    private static Account CreateTestAccount(IServiceProvider serviceProvider)
    {
      AccountsContext ctx = serviceProvider.GetRequiredService<AccountsContext>();
      var newAccount = new Account("TestAccount")
      {
        EMail = "test@illarion.org",
        Password = PasswordHashing.GetPasswordHash("test1234")
      };
      ctx.Accounts.Add(newAccount);
      ctx.SaveChanges();
      return newAccount; 
    }

    private static PhotonApplicationProxy StartTestApplication(IServiceProvider serviceProvider)
    {
      var operationHandler = new AccountOperationHandler(serviceProvider);
      var application = new TestApplication(operationHandler);
      var applicationProxy = new PhotonApplicationProxy(application);
      applicationProxy.Start();

      return applicationProxy;
    }
  }
}
