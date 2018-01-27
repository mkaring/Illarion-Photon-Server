using System;
using System.Globalization;
using Microsoft.Extensions.DependencyInjection;
using Photon.SocketServer;

namespace Illarion.Server.Photon
{
  internal sealed class PlayerPeer : PlayerPeerBase
  {
    private readonly IServiceProvider _serviceProvider;

    internal PlayerPeer(InitRequest initRequest, IServiceProvider serviceProvider) : base(initRequest)
    {
      Culture = CultureInfo.InvariantCulture;
      _serviceProvider = serviceProvider ?? throw new ArgumentNullException(nameof(serviceProvider));

      SetCurrentOperationHandler(serviceProvider.GetService<IInitialOperationHandler>());
    }
  }
}
