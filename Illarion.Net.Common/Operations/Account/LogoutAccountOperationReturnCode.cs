namespace Illarion.Net.Common.Operations.Account
{
  /// <summary>Response code for <see cref="AccountOperationCode.LogoutAccount"/>.</summary>
  /// <seealso cref="ReturnCode"/>
  public enum LogoutAccountOperationReturnCode : byte
  {
    /// <summary>The logout of the account was successful.</summary>
    /// <remarks>
    /// This response switches the operations mode.
    /// From now on the <see cref="InitialOperationCode"/> values are active.
    /// </remarks>
    Success = 0
  }
}
