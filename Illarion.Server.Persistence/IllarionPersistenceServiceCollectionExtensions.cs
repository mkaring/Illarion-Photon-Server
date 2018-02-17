using Illarion.Server.Persistence;
using Illarion.Server.Persistence.Accounts;
using Illarion.Server.Persistence.Server;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;

namespace Microsoft.Extensions.DependencyInjection
{
  public static class IllarionPersistenceServiceCollectionExtensions
  {
    public static IServiceCollection AddIllarionPersistanceContext(this IServiceCollection serviceCollection, IConfiguration configuration)
    {
      if (serviceCollection == null) throw new ArgumentNullException(nameof(serviceCollection));
      if (configuration == null) throw new ArgumentNullException(nameof(configuration));

      serviceCollection.AddEntityFrameworkNpgsql();
      serviceCollection.AddDbContextPool<AccountsContext>(b => b.UseNpgsql(configuration.GetConnectionString(nameof(AccountsContext))));
      serviceCollection.AddDbContextPool<ServerContext>(b => b.UseNpgsql(configuration.GetConnectionString(nameof(ServerContext))));
      return serviceCollection;
    }
  }
}