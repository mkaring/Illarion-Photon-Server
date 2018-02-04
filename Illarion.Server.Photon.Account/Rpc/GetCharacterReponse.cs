using Illarion.Net.Common.Operations.Account;
using Photon.SocketServer.Rpc;
using System;

namespace Illarion.Server.Photon.Rpc
{
  internal sealed class GetCharacterReponse : DataContract
  {
    [DataMember(Name = nameof(CharacterId), Code = (byte)GetCharacterOperationResponseParameterCode.CharacterId)]
    internal Guid CharacterId { get; set; }

    [DataMember(Name = nameof(CharacterName), Code = (byte)GetCharacterOperationResponseParameterCode.CharacterName)]
    internal string CharacterName { get; set; }

    [DataMember(Name = nameof(CharacterStatus), Code = (byte)GetCharacterOperationResponseParameterCode.CharacterStatus)]
    internal int CharacterStatus { get; set; }
  }
}
