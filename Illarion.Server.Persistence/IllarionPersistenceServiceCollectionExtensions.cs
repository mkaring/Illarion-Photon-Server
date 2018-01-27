using Illarion.Server.Persistence.Accounts;
using Illarion.Server.Persistence.Server;

namespace Microsoft.Extensions.DependencyInjection
{
  public static class IllarionPersistenceServiceCollectionExtensions
  {
    public static IServiceCollection AddIllarionPersistanceContext(this IServiceCollection serviceCollection)
    {
      serviceCollection.AddEntityFrameworkSqlite();
      serviceCollection.AddDbContextPool<AccountsContext>(AccountsContextFactory.BuildAccountContext);
      serviceCollection.AddDbContextPool<ServerContext>(ServerContextFactory.BuildServerContext);
      return serviceCollection;
    }
  }
}