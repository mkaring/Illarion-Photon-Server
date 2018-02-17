namespace Illarion.Net.Common
{
  public enum AccountOperationCode : byte
  {
    /// <summary>Get the list of characters currently available in the account.</summary>
    ListCharacters = 0,

    /// <summary>
    /// Get the data for a single character. The reponses to this are send as part of the response to
    /// <see cref="ListCharacters"/>.
    /// </summary>
    GetCharacter,

    /// <summary>Login with a specific character. The character has to be bound to the current account.</summary>
    /// <seealso cref="Operations.Account.LoginCharacterOperationRequestParameterCode"/>
    /// <seealso cref="Operations.Account.LoginCharacterOperationReturnCode"/>
    LoginCharacter,

    /// <summary>Logout the current connection.</summary>
    /// <seealso cref="Operations.Account.LogoutAccountOperationReturnCode"/>
    LogoutAccount
  }
}
