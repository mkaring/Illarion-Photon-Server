namespace Illarion.Net.Common.Operations.Account
{
  /// <summary>Response code for <see cref="AccountOperationCode.ListCharacters"/>.</summary>
  /// <seealso cref="ReturnCode"/>
  public enum ListCharactersOperationReturnCode : byte
  {
    /// <summary>The request was build and the characters are being returned.</summary>
    Success = 0
  }
}
