using Illarion.Server.Persistence;
using Illarion.Server.Persistence.Accounts;
using Illarion.Server.Persistence.Server;
using Microsoft.EntityFrameworkCore;

namespace Microsoft.Extensions.DependencyInjection
{
  public static class IllarionTestPersistenceServiceCollectionExtensions
  {
    public static IServiceCollection AddIllarionTestPersistanceContext(this IServiceCollection serviceCollection)
    {
      serviceCollection.AddDbContext<AccountsContext>(b => b.UseInMemoryDatabase(nameof(AccountsContext)));
      serviceCollection.AddDbContext<ServerContext>(b => b.UseInMemoryDatabase(nameof(ServerContext)));
      return serviceCollection;
    }
  }
}