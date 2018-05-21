using System;
using Illarion.Server;

namespace Microsoft.Extensions.DependencyInjection
{
  public static class IllarionWorldServiceCollectionExtensions
  {
    public static IServiceCollection AddIllarionGameService(this IServiceCollection serviceCollection)
    {
      if (serviceCollection == null) throw new ArgumentNullException(nameof(serviceCollection));

      serviceCollection.AddSingleton<IWorldManager>(p => new WorldManager(p));
      serviceCollection.AddSingleton<IMapFactory>(p => new MapFactory());

      return serviceCollection;
    }
  }
}