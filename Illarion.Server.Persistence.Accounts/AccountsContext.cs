using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ValueGeneration;

namespace Illarion.Server.Persistence.Accounts
{
  //public class AccountsContext : DbContext
  //{
  //  public AccountsContext(DbContextOptions<AccountsContext> options) : base(options)
  //  {
  //  }

  //  public DbSet<Account> Accounts { get; set; }

  //  protected override void OnModelCreating(ModelBuilder modelBuilder)
  //  {
  //    CreateModel(modelBuilder);

  //    base.OnModelCreating(modelBuilder);
  //  }
  //}

  public static class AccountsContext
  {
    public static void CreateModel(ModelBuilder modelBuilder)
    {
      if (modelBuilder == null) throw new ArgumentNullException(nameof(modelBuilder));

      modelBuilder.HasDefaultSchema("accounts");
      modelBuilder.Entity<Account>().HasKey(a => a.AccountId);
      modelBuilder.Entity<Account>().Property(a => a.AccountId).
        HasValueGenerator<SequentialGuidValueGenerator>().
        ValueGeneratedOnAdd().
        UsePropertyAccessMode(PropertyAccessMode.FieldDuringConstruction);

      modelBuilder.Entity<Account>().Property(a => a.AccountName).
        IsRequired().
        IsUnicode().
        UsePropertyAccessMode(PropertyAccessMode.FieldDuringConstruction);

      modelBuilder.Entity<Account>().Property(a => a.Password).
        IsRequired().
        UsePropertyAccessMode(PropertyAccessMode.Property);

      modelBuilder.Entity<Account>().Property(a => a.EMail).
        IsRequired().
        UsePropertyAccessMode(PropertyAccessMode.Property);

      modelBuilder.Entity<Account>().Property(a => a.Status).
        IsRequired().
        UsePropertyAccessMode(PropertyAccessMode.Property);

      modelBuilder.Entity<Account>().Property(a => a.LastSeen).
        IsRequired().
        UsePropertyAccessMode(PropertyAccessMode.Property).
        ValueGeneratedOnAddOrUpdate();

      modelBuilder.Entity<Account>().Property(a => a.Registered).
        IsRequired().
        UsePropertyAccessMode(PropertyAccessMode.FieldDuringConstruction).
        ValueGeneratedOnAdd();
    }
  }
}