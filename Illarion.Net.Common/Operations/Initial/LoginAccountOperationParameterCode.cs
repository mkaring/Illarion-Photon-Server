namespace Illarion.Net.Common.Operations.Initial
{
  public enum LoginAccountOperationParameterCode : byte
  {
    /// <summary>
    /// The name of the account encoded as <see cref="string"/>.
    /// </summary>
    AccountName = 0,

    /// <summary>
    /// The password of the account encoded as <see cref="string"/>.
    /// </summary>
    Password
  }
}
