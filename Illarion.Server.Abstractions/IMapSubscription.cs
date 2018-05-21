using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace Illarion.Server
{
  /// <summary>
  /// This interface allows accessing the map subscription system. It takes care that the character is receiving the
  /// required updates at any given moment.
  /// </summary>
  public interface IMapSubscription : IDisposable
  {
    /// <summary>Update the location of the subscriber.</summary>
    /// <param name="position">The new location.</param>
    void UpdatePosition(Vector3 position);
  }
}
