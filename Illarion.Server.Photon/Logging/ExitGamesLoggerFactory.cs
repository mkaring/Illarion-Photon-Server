using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Illarion.Server.Photon.Logging
{
  internal sealed class ExitGamesLoggerFactory : ExitGames.Logging.ILoggerFactory
  {
    private readonly IServiceProvider _services;

    internal ExitGamesLoggerFactory(IServiceProvider services) =>
      _services = services ?? throw new ArgumentNullException(nameof(services));

    public ExitGames.Logging.ILogger CreateLogger(string name)
    {
      ILoggerFactory loggerFactory = _services.GetRequiredService<ILoggerFactory>();

      return new ExitGamesLogger(name, loggerFactory.CreateLogger(name));
    }
  }
}
