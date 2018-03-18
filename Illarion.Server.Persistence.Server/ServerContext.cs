using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.ValueGeneration;

namespace Illarion.Server.Persistence.Server
{
  public sealed class ServerContext : DbContext
  {
    public ServerContext(DbContextOptions<ServerContext> options) : base(options)
    {
    }

    public DbSet<Character> Characters { get; set; }
    public DbSet<CharacterAttribute> CharacterAttributes { get; set; }
    public DbSet<Race> Races { get; set; }
    public DbSet<RaceType> RaceTypes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      CreateModel(modelBuilder);
      base.OnModelCreating(modelBuilder);
    }

    private static void CreateModel(ModelBuilder modelBuilder)
    {
      if (modelBuilder == null) throw new ArgumentNullException(nameof(modelBuilder));

      modelBuilder.HasDefaultSchema("server");

      {
        EntityTypeBuilder<Character> characterEntity = modelBuilder.Entity<Character>();

        characterEntity.HasKey(c => new { c.AccountId, c.CharacterId });

        characterEntity.Property(c => c.AccountId).
          ValueGeneratedNever();

        characterEntity.Property(c => c.CharacterId).
          HasValueGenerator<SequentialGuidValueGenerator>().
          ValueGeneratedOnAdd().
          UsePropertyAccessMode(PropertyAccessMode.FieldDuringConstruction);

        characterEntity.HasIndex(c => c.Name).IsUnique();
        characterEntity.Property(c => c.Name).
          IsRequired().IsUnicode();

        characterEntity.Property(c => c.Status).
          IsRequired().
          HasDefaultValue(CharacterStatus.Default);

        characterEntity.Property(c => c.RaceTypeId).IsRequired();

        characterEntity.Property(c => c.Location).
          IsRequired().
          HasField("_location").
          UsePropertyAccessMode(PropertyAccessMode.Field).
          HasColumnType("float[3]");

        characterEntity.Property(c => c.DayOfBirth).
          IsRequired()
          .UsePropertyAccessMode(PropertyAccessMode.FieldDuringConstruction);

        characterEntity.Property(c => c.MonthOfBirth).
          IsRequired()
          .UsePropertyAccessMode(PropertyAccessMode.FieldDuringConstruction);

        characterEntity.Property(c => c.YearOfBirth).
          IsRequired()
          .UsePropertyAccessMode(PropertyAccessMode.FieldDuringConstruction);

        characterEntity.HasMany(c => c.Attributes).WithOne(ca => ca.Character).
          HasForeignKey(ca => ca.CharacterId).
          HasPrincipalKey(c => c.CharacterId);

        characterEntity.HasOne(c => c.RaceType).WithMany(rt => rt.Characters).
          HasForeignKey(c => c.RaceTypeId).
          HasPrincipalKey(c => c.Id);
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

      {
        EntityTypeBuilder<Race> raceEntity = modelBuilder.Entity<Race>();
        raceEntity.HasKey(r => r.RaceId);

        raceEntity.Property(r => r.RaceId).UsePropertyAccessMode(PropertyAccessMode.FieldDuringConstruction);
        raceEntity.Property(r => r.IsPlayerRace).HasDefaultValue(false).IsRequired();

        raceEntity.HasMany(r => r.RaceTypes).WithOne(rt => rt.Race).HasForeignKey(rt => rt.RaceTypeId).HasPrincipalKey(r => r.RaceId);
      }

      {
        EntityTypeBuilder<RaceType> raceTypeEntity = modelBuilder.Entity<RaceType>();
        raceTypeEntity.HasKey(rt => rt.Id);
        raceTypeEntity.Property(rt => rt.Id).
          HasValueGenerator<SequentialGuidValueGenerator>().
          ValueGeneratedOnAdd().
          UsePropertyAccessMode(PropertyAccessMode.FieldDuringConstruction);

        raceTypeEntity.HasIndex(rt => new { rt.RaceId, rt.RaceTypeId }).IsUnique();

        raceTypeEntity.Property(rt => rt.Id).UsePropertyAccessMode(PropertyAccessMode.FieldDuringConstruction);
        raceTypeEntity.Property(rt => rt.RaceId).UsePropertyAccessMode(PropertyAccessMode.FieldDuringConstruction);
        raceTypeEntity.Property(rt => rt.RaceTypeId).UsePropertyAccessMode(PropertyAccessMode.FieldDuringConstruction);
      }
    }
  }
}
