namespace Illarion.Net.Common.Operations.Account
{
  /// <summary>Response code for <see cref="AccountOperationCode.GetCharacter"/>.</summary>
  /// <seealso cref="ReturnCode"/>
  public enum GetCharacterOperationReturnCode : byte
  {
    /// <summary>The character data is being returned.</summary>
    Success = 0,

    /// <summary>The requested character does not exist or is not part of the current account.</summary>
    DoesNotExist
  }
}
