using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Illarion.Server.Persistence
{
  public sealed class IllarionContextFactory : IDesignTimeDbContextFactory<IllarionContext>
  {
    IllarionContext IDesignTimeDbContextFactory<IllarionContext>.CreateDbContext(string[] args)
    {
      var optionsBuilder = new DbContextOptionsBuilder<IllarionContext>();
      BuildAccountContext(optionsBuilder);
      return new IllarionContext(optionsBuilder.Options);
    }

    public static void BuildAccountContext(DbContextOptionsBuilder builder)
    {
      if (!builder.IsConfigured)
        builder.UseSqlite("Data Source=Illarion.sqlite", sqliteBuilder => sqliteBuilder.SuppressForeignKeyEnforcement(false));
    }
  }
}