using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.EventLog;
using Photon.SocketServer;

namespace Illarion.Server.Photon
{
  public class ServerApplication : ApplicationBase
  {
    private ServiceProvider _services;

    protected override PeerBase CreatePeer(InitRequest initRequest) => new PlayerPeer(initRequest, _services);

    public ServerApplication() : base()
    {
    }

    protected override void Setup()
    {
      var services = new ServiceCollection();
      services.AddLogging(builder => builder.AddEventLog(new EventLogSettings() { SourceName = "Illarion Server"}));
      services.AddIllarionPersistanceContext();

      services.AddTransient<IInitialOperationHandler>(s => new InitialOperationHandler(s));
      services.AddTransient<IAccountOperationHandler>(s => new AccountOperationHandler(s));

      _services = services.BuildServiceProvider();
    }

    protected override void TearDown() => _services.Dispose();
  }
}
