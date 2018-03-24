using Illarion.Server.Persistence.Accounts;
using Illarion.Server.Persistence.Design;
using Illarion.Server.Persistence.Server;
using Illarion.Server.Setup.Properties;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.CommandLineUtils;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Illarion.Server.Setup
{
  internal static class MigrateDatabase
  {
    internal static void Configure(CommandLineApplication application)
    {
      application.Description = Resources.MigrateDatabaseDescription;

      application.OnExecute((Func<Task<int>>)Execute);
    }

    private static async Task<int> Execute()
    {
      try
      {
        using (AccountsContext context = new AccountsDesignTimeDbContextFactory().CreateDbContext())
        {
          await context.Database.MigrateAsync().ConfigureAwait(false);
        }

        using (ServerContext context = new ServerDesignTimeDbContextFactory().CreateDbContext())
        {
          await context.Database.MigrateAsync().ConfigureAwait(false);
        }

        return 0;
      }
      catch (Exception e)
      {
        AnsiConsole.GetError(true).WriteLine(e.Message);
        return -1;
      }
    }
  }
}
