namespace Illarion.Net.Common.Operations.Player
{
  /// <summary>Response code for <see cref="PlayerOperationCode.UpdateLocation"/>.</summary>
  /// <seealso cref="ReturnCode"/>
  public enum UpdateLocationReturnCode : byte
  {
    /// <summary>Default cause in case a location update is send to the client.</summary>
    /// <remarks>
    /// This code will be send very rarely, since the server is usually not responding to this command.
    /// </remarks>
    Success = 0
  }
}
