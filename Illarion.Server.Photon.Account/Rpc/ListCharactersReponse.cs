using Illarion.Net.Common.Operations.Account;
using Photon.SocketServer;
using Photon.SocketServer.Rpc;
using System;
using System.Collections.Generic;

namespace Illarion.Server.Photon.Rpc
{
  internal sealed class ListCharactersReponse : DataContract
  {
    [DataMember(Name = nameof(CharacterList), Code = (byte)ListCharactersOperationResponseParameterCode.CharacterList)]
    internal IList<OperationResponse> CharacterList { get; set; }
  }
}
