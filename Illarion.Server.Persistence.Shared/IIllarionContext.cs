using System.Diagnostics;

namespace Illarion.Server.Persistence
{
  public interface IIllarionContext
  {
    /// <summary>Saves all changes made in this context to the database.</summary>
    /// <returns>The number of state entries written to the database.</returns>
    /// <exception cref="Microsoft.EntityFrameworkCore.DbUpdateException">
    ///   An error is encountered while saving to the database.
    /// </exception>
    /// <exception cref="Microsoft.EntityFrameworkCore.DbUpdateConcurrencyException">
    ///   A concurrency violation is encountered while saving to the database. A concurrency
    ///   violation occurs when an unexpected number of rows are affected during save.
    ///   This is usually because the data in the database has been modified since it was
    ///   loaded into memory.
    /// </exception>
    /// <remarks>
    ///   This method will automatically call
    ///   <see cref="Microsoft.EntityFrameworkCore.ChangeTracking.ChangeTracker.DetectChanges"/> to discover any
    ///   changes to entity instances before saving to the underlying database. This can be disabled via
    ///   <see cref="Microsoft.EntityFrameworkCore.ChangeTracking.ChangeTracker.AutoDetectChangesEnabled"/>.
    /// </remarks>
    [DebuggerStepThrough]
    int SaveChanges();

    /// <summary>Saves all changes made in this context to the database.</summary>                                     
    /// <param name="acceptAllChangesOnSuccess">
    ///   Indicates whether <see cref="Microsoft.EntityFrameworkCore.ChangeTracking.ChangeTracker.AcceptAllChanges"/>
    ///   is called after the changes have been sent successfully to the database.
    /// </param>
    /// <returns>The number of state entries written to the database.</returns>
    /// <exception cref="Microsoft.EntityFrameworkCore.DbUpdateException">
    ///   An error is encountered while saving to the database.
    /// </exception>
    /// <exception cref="Microsoft.EntityFrameworkCore.DbUpdateConcurrencyException">
    ///   A concurrency violation is encountered while saving to the database. A concurrency
    ///   violation occurs when an unexpected number of rows are affected during save.
    ///   This is usually because the data in the database has been modified since it was
    ///   loaded into memory.
    /// </exception>
    /// <remarks>
    ///   This method will automatically call
    ///   <see cref="Microsoft.EntityFrameworkCore.ChangeTracking.ChangeTracker.DetectChanges"/> to discover any
    ///   changes to entity instances before saving to the underlying database. This can be disabled via
    ///   <see cref="Microsoft.EntityFrameworkCore.ChangeTracking.ChangeTracker.AutoDetectChangesEnabled"/>.
    /// </remarks>
    [DebuggerStepThrough]
    int SaveChanges(bool acceptAllChangesOnSuccess);
  }
}
