using System;
using System.ComponentModel.DataAnnotations;
using Illarion.Net.Common.Operations.Account;
using Photon.SocketServer;
using Photon.SocketServer.Rpc;

namespace Illarion.Server.Photon.Rpc
{
  internal sealed class LoginCharacterOperation : Operation
  {
    public LoginCharacterOperation(IRpcProtocol protocol, OperationRequest request) : base(protocol, request)
    {
    }

    [DataMember(Name = nameof(CharacterId), Code = (byte)LoginCharacterOperationParameterCode.CharacterId)]
    [Required]
    public Guid CharacterId { get; set; }
  }
}
