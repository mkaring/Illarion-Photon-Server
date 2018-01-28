using Illarion.Server.Persistence;

namespace Microsoft.Extensions.DependencyInjection
{
  public static class IllarionPersistenceServiceCollectionExtensions
  {
    public static IServiceCollection AddIllarionPersistanceContext(this IServiceCollection serviceCollection)
    {
      serviceCollection.AddDbContextPool<IllarionContext>(IllarionContextFactory.BuildAccountContext);
      return serviceCollection;
    }
  }
}