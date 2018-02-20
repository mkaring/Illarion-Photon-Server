namespace Illarion.Net.Common
{
  public enum AccountOperationCode : byte
  {
    /// <summary>Get the list of characters currently available in the account.</summary>
    /// <seealso cref="Operations.Account.ListCharactersOperationResponseParameterCode"/>
    /// <seealso cref="Operations.Account.ListCharactersOperationReturnCode"/>
    ListCharacters = 0,

    /// <summary>
    /// Get the data for a single character. The responses to this are send as part of the response to
    /// <see cref="ListCharacters"/>.
    /// </summary>
    /// <seealso cref="Operations.Account.GetCharacterOperationRequestParameterCode"/>
    /// <seealso cref="Operations.Account.GetCharacterOperationResponseParameterCode"/>
    /// <seealso cref="Operations.Account.GetCharacterOperationReturnCode"/>
    GetCharacter,

    /// <summary>Login with a specific character. The character has to be bound to the current account.</summary>
    /// <seealso cref="Operations.Account.LoginCharacterOperationRequestParameterCode"/>
    /// <seealso cref="Operations.Account.LoginCharacterOperationReturnCode"/>
    LoginCharacter,

    /// <summary>Logout the current connection.</summary>
    /// <seealso cref="Operations.Account.LogoutAccountOperationReturnCode"/>
    LogoutAccount,

    CreateCharacter
  }
}
