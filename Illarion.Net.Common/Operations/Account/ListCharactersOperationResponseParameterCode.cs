namespace Illarion.Net.Common.Operations.Account
{
  public enum ListCharactersOperationResponseParameterCode : byte
  {
    /// <summary>
    /// The list of characters. Encoded as <see cref="AccountOperationCode.GetCharacter"/> responses.
    /// </summary>
    CharacterList = 0
  }
}
