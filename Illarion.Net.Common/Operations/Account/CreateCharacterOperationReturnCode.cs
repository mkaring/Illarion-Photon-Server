namespace Illarion.Net.Common.Operations.Account
{
  /// <summary>Response code for <see cref="AccountOperationCode.CreateCharacter"/>.</summary>
  /// <seealso cref="ReturnCode"/>
  public enum CreateCharacterOperationReturnCode : byte
  {
    /// <summary>The character was created successfully.</summary>
    Success = 0,

    /// <summary>The character could be created using the settings provided.</summary>
    CreationPossible,

    /// <summary>The creation of the character failed.</summary>
    CreationFailed
  }
}
