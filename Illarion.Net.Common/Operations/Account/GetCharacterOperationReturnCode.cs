namespace Illarion.Net.Common.Operations.Account
{
  public enum GetCharacterOperationReturnCode : byte
  {
    /// <summary>The character data is being returned.</summary>
    Success = 0,

    /// <summary>The requested character does not exist or is not part of the current account.</summary>
    DoesNotExist,

    /// <summary>The required parameters were not set or set with the wrong types.</summary>
    Malformed
  }
}
