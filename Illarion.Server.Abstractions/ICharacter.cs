using System.Numerics;

namespace Illarion.Server
{
  /// <summary>
  /// A player is a special instance of a character in the game that is controlled remotely by a human.
  /// </summary>
  public interface ICharacter : ICharacterController
  {
    ICharacterCallback Callback { get; }

    /// <summary>The current location of the character.</summary>
    Vector3 Location { get; }

    /// <summary>The current velocity of the character.</summary>
    Vector3 Velocity { get; }

    /// <summary>The current direction the character is facing.</summary>
    Vector3 FacingDirection { get; }
  }
}
