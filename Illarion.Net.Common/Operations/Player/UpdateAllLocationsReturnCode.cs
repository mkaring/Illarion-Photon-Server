namespace Illarion.Net.Common.Operations.Player
{
  /// <summary>Response code for <see cref="PlayerOperationCode.UpdateAllLocation"/>.</summary>
  /// <seealso cref="ReturnCode"/>
  public enum UpdateAllLocationReturnCode : byte
  {
    /// <summary>Default cause in case a location update is send to the client.</summary>
    Success = 0
  }
}
