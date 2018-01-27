namespace Illarion.Net.Common
{
  public enum AccountOperationCode : byte
  {
    /// <summary>Get the list of characters currently available in the account.</summary>
    ListCharacters = 0,

    /// <summary>Login with a specific character. The character has to be bound to the current account.</summary>
    /// <seealso cref="Operations.Account.LoginCharacterOperationParameterCode"/>
    /// <seealso cref="Operations.Account.LoginCharacterOperationReturnCode"/>
    LoginCharacter,

    LogoutAccount
  }
}
