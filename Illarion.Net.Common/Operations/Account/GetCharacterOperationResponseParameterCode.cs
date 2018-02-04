namespace Illarion.Net.Common.Operations.Account
{
  public enum GetCharacterOperationResponseParameterCode : byte
  {
    /// <summary>The ID of the character, encoded as <see cref="System.Guid"/>.</summary>
    CharacterId = 0,

    /// <summary>The name of the character, encoded as <see cref="string"/>.</summary>
    CharacterName,

    /// <summary>The status of the character, encoded as <see cref="int"/>.</summary>
    CharacterStatus
  }
}
