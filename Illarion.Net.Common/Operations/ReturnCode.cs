namespace Illarion.Net.Common.Operations
{
  /// <summary>
  /// These return codes may appear in the response of any request.
  /// </summary>
  public enum ReturnCode : byte
  {
    /// <summary>An unexpected error occured while processing the command.</summary>
    InternalServerError = 254,

    /// <summary>The operation is not known.</summary>
    InvalidOperation = 255
  }
}
