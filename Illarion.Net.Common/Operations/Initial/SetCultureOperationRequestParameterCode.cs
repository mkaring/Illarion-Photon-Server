namespace Illarion.Net.Common.Operations.Initial
{
  public enum SetCultureOperationRequestParameterCode : byte
  {
    /// <summary>
    /// The name of the culture. Expects something like "de-DE" or "en-US".
    /// It will try to find the best matching localization and default to English when in doubt.
    /// Once set all messages send to the client will be localized in this language.
    /// </summary>
    /// <remarks>This parameter is required.</remarks>
    CultureName = 0
  }
}
