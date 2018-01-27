using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Illarion.Server.Persistence.Server
{
  public sealed class ServerContextFactory : IDesignTimeDbContextFactory<ServerContext>
  {
    ServerContext IDesignTimeDbContextFactory<ServerContext>.CreateDbContext(string[] args)
    {
      var optionsBuilder = new DbContextOptionsBuilder<ServerContext>();
      BuildServerContext(optionsBuilder);
      return new ServerContext(optionsBuilder.Options);
    }

    public static void BuildServerContext(DbContextOptionsBuilder builder) =>
      builder.UseSqlite("Data Source=Servers.sqlite", sqliteBuilder => sqliteBuilder.SuppressForeignKeyEnforcement(false));
  }
}