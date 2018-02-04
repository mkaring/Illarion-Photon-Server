using Illarion.Net.Common.Operations.Account;
using Photon.SocketServer;
using Photon.SocketServer.Rpc;
using System;
using System.ComponentModel.DataAnnotations;

namespace Illarion.Server.Photon.Rpc
{
  internal sealed class GetCharacterOperation : Operation
  {
    public GetCharacterOperation(IRpcProtocol protocol, OperationRequest request) : base(protocol, request)
    {
    }

    [DataMember(Name = nameof(CharacterId), Code = (byte)GetCharacterOperationRequestParameterCode.CharacterId)]
    [Required]
    public Guid CharacterId { get; set; }
  }
}
