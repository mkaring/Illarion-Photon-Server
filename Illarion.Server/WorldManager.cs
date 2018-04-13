using System;
using System.Collections.Immutable;

namespace Illarion.Server
{
  internal class WorldManager : IWorldManager
  {
    private ImmutableDictionary<int, World> _worlds;

    private IServiceProvider ServiceProvider { get; }

    private IImmutableDictionary<int, World> Worlds => _worlds;

    internal WorldManager(IServiceProvider provider)
    {
      ServiceProvider = provider ?? throw new ArgumentNullException(nameof(provider));
      _worlds = ImmutableDictionary.Create<int, World>();

      // TODO: For the moment we only got a single "world" with the index 0. That needs to change in future versions.
      _worlds = _worlds.Add(0, new World(provider));
    }

    IWorld IWorldManager.GetWorld(int index)
    {
      if (_worlds.TryGetValue(index, out World world))
      {
        return world;
      }
      throw new ArgumentOutOfRangeException(nameof(index), index, "There is no world available for the selected index.");
    }
  }
}
