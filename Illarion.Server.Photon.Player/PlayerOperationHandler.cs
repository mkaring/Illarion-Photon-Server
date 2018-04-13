using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Illarion.Net.Common;
using Photon.SocketServer;

namespace Illarion.Server.Photon
{
  public sealed class PlayerOperationHandler : PlayerPeerOperationHandler, IPlayerOperationHandler
  {
    private readonly IServiceProvider _services;

    public PlayerOperationHandler(IServiceProvider services) : base(services) => _services = services ?? throw new ArgumentNullException(nameof(services));

    protected override void OnDisconnect(PlayerPeerBase peer)
    {
    }

    protected override OperationResponse OnOperationRequest(PlayerPeerBase peer, OperationRequest operationRequest, SendParameters sendParameters)
    {
      if (peer == null) throw new ArgumentNullException(nameof(peer));
      if (operationRequest == null) throw new ArgumentNullException(nameof(operationRequest));

      switch ((PlayerOperationCode)operationRequest.OperationCode)
      {
        case PlayerOperationCode.LoadingReady:
          break;
        case PlayerOperationCode.LogoutPlayer:
          break;
        case PlayerOperationCode.SendMessage:
          break;
        case PlayerOperationCode.UpdateAllLocations:
          break;
        case PlayerOperationCode.UpdateAppearance:
          break;
        case PlayerOperationCode.UpdateLocation:
          break;
      }

      return InvalidOperation(operationRequest);
    }
  }
}
