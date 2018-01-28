using Illarion.Server.Persistence.Accounts;
using Illarion.Server.Persistence.Server;
using Microsoft.EntityFrameworkCore;

namespace Illarion.Server.Persistence
{
  public class IllarionContext : DbContext
  {
    public IllarionContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Account> Accounts { get; set; }
    public DbSet<Character> Characters { get; set; }
    public DbSet<CharacterAttribute> CharacterAttributes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      AccountsContext.CreateModel(modelBuilder);
      ServerContext.CreateModel(modelBuilder);

      base.OnModelCreating(modelBuilder);
    }



    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
      IllarionContextFactory.BuildAccountContext(optionsBuilder);
  }
}
