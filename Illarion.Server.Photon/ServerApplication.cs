using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.EventLog;
using Photon.SocketServer;
using System;

namespace Illarion.Server.Photon
{
  public class ServerApplication : ApplicationBase
  {
    private IServiceProvider _services;
    private IServiceProviderFactory<IServiceCollection> _serviceProviderFactory;

    public ServerApplication() : this(new DefaultServiceProviderFactory())
    {
    }

    public ServerApplication(IServiceProviderFactory<IServiceCollection> serviceProviderFactory) =>
      _serviceProviderFactory = serviceProviderFactory ?? throw new ArgumentNullException(nameof(serviceProviderFactory));

    protected override PeerBase CreatePeer(InitRequest initRequest) => new PlayerPeer(initRequest, _services);

    protected override void Setup()
    {
      IServiceCollection services = _serviceProviderFactory.CreateBuilder(new ServiceCollection());
      services.AddLogging(builder =>
        {
          //builder.AddEventLog(new EventLogSettings() { SourceName = "Application", LogName="Illarion Server", Filter = (m, l) => l >= LogLevel.Error });
          builder.AddConsole();
#if DEBUG
          builder.AddDebug();
#endif
        });
      services.AddIllarionPersistanceContext();

      services.AddTransient<IInitialOperationHandler>(s => new InitialOperationHandler(s));
      services.AddTransient<IAccountOperationHandler>(s => new AccountOperationHandler(s));

      _services = _serviceProviderFactory.CreateServiceProvider(services);

      SetupPhotonLogging(_services);
    }

    protected override void TearDown() => (_services as IDisposable)?.Dispose();

    private static void SetupPhotonLogging(IServiceProvider services) =>
      ExitGames.Logging.LogManager.SetLoggerFactory(new Logging.ExitGamesLoggerFactory(services));

    private void AppDomain_OnUnhandledException(object sender, UnhandledExceptionEventArgs e)
    {
      var exception = e.ExceptionObject as Exception;
      LogLevel level = e.IsTerminating ? LogLevel.Critical : LogLevel.Error;

      _services.GetRequiredService<ILoggerFactory>().
        CreateLogger(nameof(ServerApplication)).
        Log(level, 0, e.ExceptionObject.ToString(), exception, (m, ex) => m);;
    }
  }
}
