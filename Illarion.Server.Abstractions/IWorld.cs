using System;

namespace Illarion.Server
{
  public interface IWorld
  {
    /// <summary>This is the map of this specific world.</summary>
    IMap Map { get; }

    /// <summary>Create a new character for this world.</summary>
    /// <param name="callbackFactory">The factory to create a character.</param>
    /// <returns>The newly created instance.</returns>
    ICharacter CreateNewCharacter(Func<ICharacter, ICharacterCallback> callbackFactory);

    /// <summary>Add a character to this world. This causes the character instance to be spawned in the world.</summary>
    /// <param name="character">The character to add. Has to be created using <see cref="CreateNetPlayer()"/></param>
    /// <exception cref="ArgumentNullException"><paramref name="character"/> is <see langword="null"/>.</exception>
    /// <exception cref="ArgumentException">
    /// <paramref name="character"/> was not created for this <see cref="IWorld"/>.
    /// </exception>
    /// <remarks>
    /// This should be done once the <see cref="ICharacter"/> instance to properly connected to the client connection and
    /// client is done loading the world.
    /// </remarks>
    void AddCharacter(ICharacter character);

    /// <summary>
    /// Remove a character from the world. This needs to be done of the character switches worlds or in case the
    /// character loggs out from the game.
    /// </summary>
    /// <param name="character">The character instance that should be logged out.</param>
    /// <exception cref="ArgumentNullException"><paramref name="character"/> is <see langword="null"/>.</exception>
    /// <exception cref="ArgumentException">
    /// <paramref name="character"/> is not part of this <see cref="World"/>.
    /// </exception>
    void RemoveCharacter(ICharacter character);
  }
}
