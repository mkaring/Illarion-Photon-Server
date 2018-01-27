namespace Illarion.Net.Common.Operations.Account
{
  public enum LoginCharacterOperationReturnCode : byte
  {
    /// <summary>The login with the character was accepted.</summary>
    Success = 0,

    /// <summary>The requested character does not exist or is not part of the current account.</summary>
    DoesNotExist,

    /// <summary>The requested character is currently not allowed to log in.</summary>
    Blocked,

    /// <summary>The required parameters were not set or set with the wrong types.</summary>
    Malformed
  }
}
