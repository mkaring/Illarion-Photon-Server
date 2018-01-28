using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.ValueGeneration;

namespace Illarion.Server.Persistence.Server
{
  //public class ServerContext : DbContext
  //{
  //  public ServerContext(DbContextOptions<ServerContext> options) : base(options)
  //  {
  //  }

  //  public DbSet<Character> Characters { get; set; }
  //  public DbSet<CharacterAttribute> CharacterAttributes { get; set; }

  //  protected override void OnModelCreating(ModelBuilder modelBuilder)
  //  {
  //    CreateModel(modelBuilder);
  //    base.OnModelCreating(modelBuilder);
  //  }
  //}

  public static class ServerContext
  {
    public static void CreateModel(ModelBuilder modelBuilder)
    {
      if (modelBuilder == null) throw new ArgumentNullException(nameof(modelBuilder));

      modelBuilder.HasDefaultSchema("server");

      {
        EntityTypeBuilder<Character> characterEntity = modelBuilder.Entity<Character>();

        characterEntity.HasKey(a => new { a.AccountId, a.CharacterId });

        characterEntity.Property(a => a.AccountId).
          ValueGeneratedNever();

        characterEntity.Property(a => a.CharacterId).
          HasValueGenerator<SequentialGuidValueGenerator>().
          ValueGeneratedOnAdd().
          UsePropertyAccessMode(PropertyAccessMode.FieldDuringConstruction);

        characterEntity.HasIndex(a => a.Name).IsUnique();
        characterEntity.Property(a => a.Name).
          IsRequired().IsUnicode();

        characterEntity.Property(a => a.Status).
          IsRequired().
          HasDefaultValue(CharacterStatus.Default);

        characterEntity.HasMany(c => c.Attributes).WithOne(c => c.Character).
          HasForeignKey(ca => ca.CharacterId).
          HasPrincipalKey(c => c.CharacterId);
      }

      {
        EntityTypeBuilder<CharacterAttribute> characterAttributeEntity = modelBuilder.Entity<CharacterAttribute>();
        characterAttributeEntity.HasKey(ca => new { ca.CharacterId, ca.AttributeId });

        characterAttributeEntity.Property(ca => ca.CharacterId).
          UsePropertyAccessMode(PropertyAccessMode.FieldDuringConstruction);

        characterAttributeEntity.Property(ca => ca.AttributeId).
          UsePropertyAccessMode(PropertyAccessMode.FieldDuringConstruction);

        characterAttributeEntity.Property(ca => ca.Value).IsRequired();
      }
    }
  }
}
