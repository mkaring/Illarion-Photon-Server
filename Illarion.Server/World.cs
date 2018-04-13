using System;
using System.Collections.Immutable;

namespace Illarion.Server
{
  /// <summary>
  /// A <see cref="World"/> is a single map and all the supporting facilities dedicated to this map. Different
  /// instances of the <see cref="World"/> represend isolated maps that mostly run without effecting each other.
  /// </summary>
  internal sealed class World : IWorld
  {
    private IImmutableSet<Character> _players;

    private IServiceProvider ServiceProvider { get; }

    internal World(IServiceProvider provider)
    {
      ServiceProvider = provider ?? throw new ArgumentNullException(nameof(provider));

      _players = ImmutableHashSet.Create<Character>();
    }

    ICharacter IWorld.CreateNewCharacter(Func<ICharacter, ICharacterCallback> callbackFactory)
    {
      var player = new Character(this);
      player.Callback = callbackFactory(player);
      return player;
    }

    void IWorld.AddCharacter(ICharacter player)
    {
      if (player == null) throw new ArgumentNullException(nameof(player));

      var checkedPlayer = player as Character;
      if (checkedPlayer == null || checkedPlayer.World != this)
      {
        throw new ArgumentException("The player instance was not created for this world.", nameof(player));
      }

      if (!ImmutableInterlocked.Update(ref _players, s => s.Add(checkedPlayer)))
      {
        throw new ArgumentException("Player seems to be already present in this world.", nameof(player));
      }
    }

    void IWorld.RemoveCharacter(ICharacter player)
    {
      if (player == null) throw new ArgumentNullException(nameof(player));

      var checkedPlayer = player as Character;
      if (checkedPlayer == null || checkedPlayer.World != this)
      {
        throw new ArgumentException("The player instance was not created for this world.", nameof(player));
      }

      ImmutableInterlocked.Update(ref _players, s => s.Remove(checkedPlayer));
    }
  }
}
