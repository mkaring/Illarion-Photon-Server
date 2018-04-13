using System;
using Illarion.Server;

namespace Microsoft.Extensions.DependencyInjection
{
  public static class IllarionWorldServiceCollectionExtensions
  {
    public static IServiceCollection AddIllarionWorldManager(this IServiceCollection serviceCollection)
    {
      if (serviceCollection == null) throw new ArgumentNullException(nameof(serviceCollection));

      serviceCollection.AddSingleton<IWorldManager>(p => new WorldManager(p));

      return serviceCollection;
    }
  }
}