using System;
using System.Collections.Generic;
using System.Text;

namespace Illarion.Server
{
  /// <summary>This interface defines a entity that is able to subscribe to updates from the map.</summary>
  public interface IMapSubscriber
  {
    /// <summary>The subscription on the map that is currently active for this subscriber.</summary>
    IMapSubscription Subscription { get; set; }
  }
}
