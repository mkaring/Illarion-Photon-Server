namespace Illarion.Net.Common.Operations.Player
{
  public enum UpdateLocationOperationRequestParameterCode : byte
  {
    /// <summary>
    /// The current location of the character at the time of this update.
    /// Encoded as <see cref="CustomTypeCode.Vector"/>.
    /// </summary>
    Location = 0,

    /// <summary>
    /// The current direction the character is facing.
    /// Encoded as <see cref="CustomTypeCode.Vector"/>.
    /// </summary>
    LookAtDirection,

    /// <summary>
    /// The current movement velocity.
    /// Encoded as <see cref="CustomTypeCode.Vector"/>.
    /// </summary>
    Velocity
  }
}
