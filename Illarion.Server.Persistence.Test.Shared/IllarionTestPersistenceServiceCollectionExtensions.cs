using Illarion.Server.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Microsoft.Extensions.DependencyInjection
{
  public static class IllarionTestPersistenceServiceCollectionExtensions
  {
    public static IServiceCollection AddIllarionTestPersistanceContext(this IServiceCollection serviceCollection)
    {
      serviceCollection.AddDbContextPool<IllarionContext>(b => b.UseInMemoryDatabase("Illarion"));
      serviceCollection.AddTransient<IAccountsContext>(sp => sp.GetService<IllarionContext>());
      serviceCollection.AddTransient<IServerContext>(sp => sp.GetService<IllarionContext>());
      return serviceCollection;
    }
  }
}