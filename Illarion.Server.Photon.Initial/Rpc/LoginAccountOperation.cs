using System.ComponentModel.DataAnnotations;
using Illarion.Net.Common.Operations.Initial;
using Photon.SocketServer;
using Photon.SocketServer.Rpc;

namespace Illarion.Server.Photon.Rpc
{
  internal sealed class LoginAccountOperation : Operation
  {
    internal LoginAccountOperation(IRpcProtocol protocol, OperationRequest request) : base(protocol, request)
    {
    }

    [DataMember(Name = nameof(AccountName), Code = (byte)LoginAccountOperationParameterCode.AccountName)]
    [Required]
    public string AccountName { get; set; }

    [DataMember(Name = nameof(Password), Code = (byte)LoginAccountOperationParameterCode.Password)]
    [Required]
    public string Password { get; set; }
  }
}
