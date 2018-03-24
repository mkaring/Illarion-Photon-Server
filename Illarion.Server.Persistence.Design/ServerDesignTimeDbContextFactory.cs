using Illarion.Server.Persistence.Server;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace Illarion.Server.Persistence.Design
{
  public class ServerDesignTimeDbContextFactory : IDesignTimeDbContextFactory<ServerContext>
  {
    public ServerContext CreateDbContext(params string[] args)
    {
      IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("IllarionServerConfig.json")
            .Build();

      var builder = new DbContextOptionsBuilder<ServerContext>();

      builder.UseNpgsql(configuration.GetConnectionString(nameof(ServerContext)), b => b.
        MigrationsAssembly("Illarion.Server.Persistence.Server.Migrations").
        MigrationsHistoryTable("SchemaMigration", "server"));

      return new ServerContext(builder.Options);
    }
  }
}
