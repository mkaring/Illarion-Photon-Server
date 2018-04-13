using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace Illarion.Server
{
  /// <summary>
  /// This interface defines all the commands that may be executed in order to control an character.
  /// </summary>
  public interface ICharacterController
  {
    /// <summary>Update the current movement information of the character.</summary>
    /// <param name="location">The current location of the character.</param>
    /// <param name="velocity">The current movement velocity and direction.</param>
    /// <param name="facing">The diretion the character is facing.</param>
    /// <returns><see langword="true"/> in case the update was accepted.</returns>
    bool UpdateMovement(Vector3 location, Vector3 velocity, Vector3 facing);

    /// <summary>
    /// Send a chat message.
    /// </summary>
    /// <param name="channel">The chat channel that defines how the message is send.</param>
    /// <param name="text">The text that is actually send.</param>
    void Chat(IChatChannel channel, string text);
  }
}
