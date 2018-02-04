namespace Illarion.Net.Common.Operations.Account
{
  public enum ListCharactersOperationReturnCode : byte
  {
    /// <summary>The request was build and the characters are beeing returned.</summary>
    Success = 0,

    /// <summary>The required parameters were not set or set with the wrong types.</summary>
    Malformed
  }
}
