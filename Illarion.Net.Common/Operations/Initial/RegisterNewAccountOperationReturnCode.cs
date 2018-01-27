namespace Illarion.Net.Common.Operations.Initial
{
  public enum RegisterNewAccountOperationReturnCode : byte
  {
    /// <summary>The account was successfully created.</summary>
    Success = 0,

    /// <summary>The account was not created. The name is already used.</summary>
    AccountNameAlreadyUsed,

    /// <summary>The account was not created. The e-mail is already in use.</summary>
    EMailAlreadyUsed,

    /// <summary>The creation information for a new account are only accepted over a encrypted connection.</summary>
    NotEncrypted,

    /// <summary>The required parameters were not set or set with the wrong types.</summary>
    Malformed
  }
}
