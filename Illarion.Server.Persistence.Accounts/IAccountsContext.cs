using Illarion.Server.Persistence.Accounts;
using Microsoft.EntityFrameworkCore;

namespace Illarion.Server.Persistence
{
  public interface IAccountsContext : IIllarionContext
  {
    DbSet<Account> Accounts { get; set; }
  }
}
