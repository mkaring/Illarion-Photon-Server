namespace Illarion.Net.Common.Operations.Initial
{
  /// <summary>Response code for <see cref="InitialOperationCode.LoginAccount"/>.</summary>
  /// <seealso cref="ReturnCode"/>
  public enum LoginAccountOperationReturnCode : byte
  {
    /// <summary>The login to the account was successful.</summary>
    /// <remarks>
    /// This response switches the operations mode.
    /// From now on the <see cref="AccountOperationCode"/> values are active.
    /// </remarks>
    Success = 0,

    /// <summary>The login or the password was wrong.</summary>
    WrongNameOrPassword,

    /// <summary>The login information were correct, but the account is not allowed to login.</summary>
    Blocked,

    /// <summary>This commands accepts the login information only in case they are send encrypted.</summary>
    NotEncrypted
  }
}
