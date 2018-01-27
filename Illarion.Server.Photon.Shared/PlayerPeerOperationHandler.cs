using Illarion.Net.Common.Operations;
using Photon.SocketServer;
using Photon.SocketServer.Rpc;
using System;

namespace Illarion.Server.Photon
{
  public abstract class PlayerPeerOperationHandler : IOperationHandler
  {
    protected PlayerPeerOperationHandler()
    {
    }

    public virtual void OnDisconnect(PeerBase peer)
    {
      if (peer == null) OnDisconnect(null);

      var connectedUser = peer as PlayerPeerBase;
      if (connectedUser == null) throw new ArgumentException("Unexpected type of peer.", nameof(peer));

      OnDisconnect(connectedUser);
    }

    public OperationResponse OnOperationRequest(PeerBase peer, OperationRequest operationRequest, SendParameters sendParameters)
    {
      if (peer == null) return OnOperationRequest(null, operationRequest, sendParameters);

      var connectedUser = peer as PlayerPeerBase;
      if (connectedUser == null) throw new ArgumentException("Unexpected type of peer.", nameof(peer));

      return OnOperationRequest(connectedUser, operationRequest, sendParameters);
    }

    protected abstract void OnDisconnect(PlayerPeerBase peer);
    protected abstract OperationResponse OnOperationRequest(PlayerPeerBase peer, OperationRequest operationRequest, SendParameters sendParameters);

    protected static OperationResponse InvalidOperation(OperationRequest operationRequest) =>
      new OperationResponse(operationRequest.OperationCode)
      {
        ReturnCode = (int)ReturnCode.InvalidOperation,
        DebugMessage = "InvalidOperation: " + operationRequest.OperationCode
      };
  }
}
