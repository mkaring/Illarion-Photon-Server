using System;
using System.Collections.Immutable;
using Microsoft.Extensions.DependencyInjection;

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

    public IMap Map { get; }

    internal World(IServiceProvider provider)
    {
      ServiceProvider = provider ?? throw new ArgumentNullException(nameof(provider));

      _players = ImmutableHashSet.Create<Character>();
      Map = provider.GetRequiredService<IMapFactory>().CreateMap();
    }

    ICharacter IWorld.CreateNewCharacter(Func<ICharacter, ICharacterCallback> callbackFactory)
    {
      var player = new Character(this);
      player.Callback = callbackFactory(player);
      return player;
    }

    void IWorld.AddCharacter(ICharacter player)
    {
      Character checkedPlayer = GetOfThisWorld(player);

      if (!ImmutableInterlocked.Update(ref _players, s => s.Add(checkedPlayer)))
      {
        throw new ArgumentException("Player seems to be already present in this world.", nameof(player));
      }
    }

    void IWorld.RemoveCharacter(ICharacter player)
    {
      Character checkedPlayer = GetOfThisWorld(player);

      ImmutableInterlocked.Update(ref _players, s => s.Remove(checkedPlayer));
    }

    private Character GetOfThisWorld(ICharacter character)
    {
      if (character == null) throw new ArgumentNullException(nameof(character));
      if (!(character is Character checkedCharacter) || checkedCharacter.World != this)
      {
        throw new ArgumentException("The character instance was not created for this world.", nameof(character));
      }
      return checkedCharacter;
    }
  }
}
