using Xunit.Abstractions;

namespace Microsoft.Extensions.DependencyInjection
{
  public static class IllarionTestLoggingServiceCollectionExtensions
  {
    public static IServiceCollection AddIllarionTestLogging(this IServiceCollection serviceCollection, ITestOutputHelper output)
    {
      serviceCollection.AddLogging(b => b.AddXunit(output));
      return serviceCollection;
    }
    public static IServiceCollection AddIllarionTestLogging(this IServiceCollection serviceCollection, ITestOutputHelper output, Logging.LogLevel minLevel)
    {
      serviceCollection.AddLogging(b => b.AddXunit(output, minLevel));
      return serviceCollection;
    }
  }
}