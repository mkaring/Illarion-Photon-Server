using System;
using Photon.SocketServer;
using Photon.SocketServer.Rpc;

namespace Illarion.Server.Photon
{
  public class TestApplication : ApplicationBase
  {
    public IOperationHandler TestOperationHandler { get; }

    public PlayerPeerBase LastCreatedPeer { get; private set; }

    public TestApplication(IOperationHandler testOperationHandler) =>
      TestOperationHandler = testOperationHandler ?? throw new ArgumentNullException(nameof(testOperationHandler));



    protected override PeerBase CreatePeer(InitRequest initRequest)
    {
      var peer = new TestPlayerPeer(initRequest);
      peer.SetCurrentOperationHandler(TestOperationHandler);
      LastCreatedPeer = peer;
      return peer;
    }

    protected override void Setup()
    {
    }

    protected override void TearDown()
    {
    }
  }
}
