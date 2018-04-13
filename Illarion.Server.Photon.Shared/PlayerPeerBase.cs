using System.Globalization;
using Illarion.Server.Persistence.Accounts;
using Illarion.Server.Persistence.Server;
using Photon.SocketServer;
using Photon.SocketServer.Rpc;

namespace Illarion.Server.Photon
{
  public abstract class PlayerPeerBase : Peer
  {
    public CultureInfo Culture { get; set; }
    public Account Account { get; set; }
    public Character Character { get; set; }
    public ICharacterController CharacterController { get; set; }

    protected PlayerPeerBase(InitRequest initRequest) : base(initRequest)
    {
    }
  }
}
