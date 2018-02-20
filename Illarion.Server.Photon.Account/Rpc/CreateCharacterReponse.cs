using Illarion.Net.Common.Operations.Account;
using Photon.SocketServer.Rpc;
using System;
using System.Collections.Generic;

namespace Illarion.Server.Photon.Rpc
{
  internal sealed class CreateCharacterReponse : DataContract
  {
    [DataMember(Name = nameof(CharacterId), Code = (byte)CreateCharacterOperationResponseParameterCode.CharacterId, IsOptional = true)]
    internal Guid CharacterId { get; set; }

    [DataMember(Name = nameof(InvalidFields), Code = (byte)CreateCharacterOperationResponseParameterCode.InvalidFields)]
    internal List<byte> InvalidFields { get; set; }

    [DataMember(Name = nameof(InvalidParamterMessages), Code = (byte)CreateCharacterOperationResponseParameterCode.InvalidParamterMessages)]
    internal List<string> InvalidParamterMessages { get; set; }
  }
}
