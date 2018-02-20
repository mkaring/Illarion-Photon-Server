namespace Illarion.Net.Common.Operations
{
  /// <summary>
  /// These return codes may appear in the response of any request.
  /// </summary>
  public enum ReturnCode : byte
  {
    /// <summary>
    /// The request parameters are not set up correctly. They may have the wrong data type or required parameters are
    /// missing. In any case the debug message field should contain more detailed information.
    /// </summary>
    MalformedRequest = 253,

    /// <summary>An unexpected error occurred while processing the command.</summary>
    InternalServerError = 254,

    /// <summary>The operation is not known.</summary>
    InvalidOperation = 255
  }
}
