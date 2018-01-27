using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Illarion.Server.Persistence.Accounts
{
  public sealed class AccountsContextFactory : IDesignTimeDbContextFactory<AccountsContext>
  {
    AccountsContext IDesignTimeDbContextFactory<AccountsContext>.CreateDbContext(string[] args)
    {
      var optionsBuilder = new DbContextOptionsBuilder<AccountsContext>();
      BuildAccountContext(optionsBuilder);
      return new AccountsContext(optionsBuilder.Options);
    }

    public static void BuildAccountContext(DbContextOptionsBuilder builder) =>
      builder.UseSqlite("Data Source=Accounts.sqlite", sqliteBuilder => sqliteBuilder.SuppressForeignKeyEnforcement(false));
  }
}