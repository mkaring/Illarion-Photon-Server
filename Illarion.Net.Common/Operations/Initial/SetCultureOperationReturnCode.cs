namespace Illarion.Net.Common.Operations.Initial
{
  public enum SetCultureOperationReturnCode : byte
  {
    /// <summary>Culture successfully changed.</summary>
    Success = 0,

    /// <summary>The required parameters were not set or set with the wrong types.</summary>
    Malformed
  }
}
