namespace Illarion.Net.Common.Operations.Player
{
  public enum UpdateLocationOperationReponseParameterCode : byte
  {
    /// <summary>
    /// The character ID of the character this update relates to.
    /// Encoded as <see cref="System.Guid"/>
    /// </summary>
    CharacterId = 0,

    /// <summary>
    /// The current location of the character at the time of this update.
    /// Encoded as <see cref="CustomTypeCode.Vector"/>.
    /// </summary>
    Location,

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
