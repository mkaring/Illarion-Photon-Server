using Illarion.Server.Persistence.Accounts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace Illarion.Server.Persistence.Design
{
  public class AccountsDesignTimeDbContextFactory : IDesignTimeDbContextFactory<AccountsContext>
  {
    public AccountsContext CreateDbContext(string[] args)
    {
      IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("IllarionServerConfig.json")
            .Build();

      var builder = new DbContextOptionsBuilder<AccountsContext>();

      builder.UseNpgsql(configuration.GetConnectionString(nameof(AccountsContext)), b => b.MigrationsAssembly("Illarion.Server.Persistence.Accounts.Migrations"));

      return new AccountsContext(builder.Options);
    }
  }
}
