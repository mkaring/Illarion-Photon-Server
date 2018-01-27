using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Mail;
using Illarion.Net.Common;
using Illarion.Net.Common.Operations.Initial;
using Illarion.Server.Persistence.Accounts;
using Illarion.Server.Photon.Rpc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Photon.SocketServer;

namespace Illarion.Server.Photon
{
  public sealed class InitialOperationHandler : PlayerPeerOperationHandler, IInitialOperationHandler
  {
    private readonly IServiceProvider _services;

    public InitialOperationHandler(IServiceProvider services) => _services = services ?? throw new ArgumentNullException(nameof(services));

    protected override void OnDisconnect(PlayerPeerBase peer)
    {
    }

    protected override OperationResponse OnOperationRequest(PlayerPeerBase peer, OperationRequest operationRequest, SendParameters sendParameters)
    {
      if (peer == null) throw new ArgumentNullException(nameof(peer));
      if (operationRequest == null) throw new ArgumentNullException(nameof(operationRequest));

      switch ((InitialOperationCode)operationRequest.OperationCode)
      {
        case InitialOperationCode.SetCulture:
          return OnSetCultureOperationRequest(peer, operationRequest);
        case InitialOperationCode.LoginAccount:
          return OnLoginAccountOperationRequest(peer, operationRequest, sendParameters);
        case InitialOperationCode.RegisterNewAccount:
          return OnRegisterNewAccountOperationRequest(peer, operationRequest, sendParameters);
      }

      return InvalidOperation(operationRequest);
    }

    private OperationResponse OnSetCultureOperationRequest(PlayerPeerBase peer, OperationRequest operationRequest)
    {
      var operation = new SetCultureOperation(peer.Protocol, operationRequest);
      if (operation.IsValid)
      {
        peer.Culture = operation.Culture;
        return new OperationResponse(operationRequest.OperationCode) { ReturnCode = (byte)SetCultureOperationReturnCode.Success };
      }
      else
      {
        return new OperationResponse(operationRequest.OperationCode) { ReturnCode = (byte)SetCultureOperationReturnCode.Malformed, DebugMessage = operation.GetErrorMessage() };
      }
    }

    private OperationResponse OnLoginAccountOperationRequest(PlayerPeerBase peer, OperationRequest operationRequest, SendParameters sendParameters)
    {
      if (!sendParameters.Encrypted)
        return new OperationResponse(operationRequest.OperationCode) { ReturnCode = (byte)LoginAccountOperationReturnCode.NotEncrypted };

      var operation = new LoginAccountOperation(peer.Protocol, operationRequest);
      if (operation.IsValid)
      {
        Account matchingAccount = _services.GetRequiredService<AccountsContext>().Accounts.
          Where(a => a.AccountName.Equals(operation.AccountName, StringComparison.Ordinal)).
          FirstOrDefault();

        if ((matchingAccount != null) && (matchingAccount.Password.Equals(operation.Password, StringComparison.Ordinal)))
        {
          peer.Account = matchingAccount;
          peer.SetCurrentOperationHandler(_services.GetRequiredService<IAccountOperationHandler>());
          return new OperationResponse(operationRequest.OperationCode) { ReturnCode = (byte)LoginAccountOperationReturnCode.Success };
        }
        else
        {
          return new OperationResponse(operationRequest.OperationCode) { ReturnCode = (byte)LoginAccountOperationReturnCode.WrongNameOrPassword };
        }
      }
      else
      {
        return new OperationResponse(operationRequest.OperationCode) { ReturnCode = (byte)LoginAccountOperationReturnCode.Malformed, DebugMessage = operation.GetErrorMessage() };
      }
    }

    private OperationResponse OnRegisterNewAccountOperationRequest(PlayerPeerBase peer, OperationRequest operationRequest, SendParameters sendParameters)
    {
      if (!sendParameters.Encrypted)
        return new OperationResponse(operationRequest.OperationCode) { ReturnCode = (byte)RegisterNewAccountOperationReturnCode.NotEncrypted };

      var operation = new RegisterNewAccountOperation(peer.Protocol, operationRequest);
      if (operation.IsValid && Validator.TryValidateObject(operation, new ValidationContext(operation), null))
      {
        DbSet<Account> accounts = _services.GetRequiredService<AccountsContext>().Accounts;
        Account matchingAccountName = accounts.Where(a => a.AccountName.Equals(operation.AccountName, StringComparison.Ordinal)).FirstOrDefault();

        if (matchingAccountName != null)
        {
          return new OperationResponse(operationRequest.OperationCode) { ReturnCode = (byte)RegisterNewAccountOperationReturnCode.AccountNameAlreadyUsed };
        }

        Account matchingMail = accounts.Where(a => (new MailAddress(a.EMail).Equals(operation.EMail))).FirstOrDefault();

        if (matchingMail != null)
        {
          return new OperationResponse(operationRequest.OperationCode) { ReturnCode = (byte)RegisterNewAccountOperationReturnCode.EMailAlreadyUsed };
        }

        accounts.Add(new Account(operation.AccountName) { EMail = operation.EMail.ToString(), Password = operation.Password });

        return new OperationResponse(operationRequest.OperationCode) { ReturnCode = (byte)RegisterNewAccountOperationReturnCode.Success };
      }
      else
      {
        return new OperationResponse(operationRequest.OperationCode) { ReturnCode = (byte)RegisterNewAccountOperationReturnCode.Malformed, DebugMessage = operation.GetErrorMessage() };
      }
    }
  }
}
