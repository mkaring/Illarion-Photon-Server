namespace Illarion.Net.Common.Operations.Account
{
  public enum CreateCharacterOperationRequestParameterCode : byte
  {
    /// <summary>The name of the character to create. Encoded as <see cref="string"/>.</summary>
    CharacterName = 0,

    /// <summary>
    /// Only preview the creation and not actually create the character. This may be used to check the current
    /// parameters. If that parameter is present and set to <see langword="true" />, the character creation is handled
    /// as preview.
    /// </summary>
    Preview,

    #region attributes
    /// <summary>The strength the new character should have. Encoded as <see cref="int"/>.</summary>
    Strength,

    /// <summary>The constitution the new character should have. Encoded as <see cref="int"/>.</summary>
    Constitution,

    /// <summary>The dexterity the new character should have. Encoded as <see cref="int"/>.</summary>
    Dexterity,

    /// <summary>The agility the new character should have. Encoded as <see cref="int"/>.</summary>
    Agility,

    /// <summary>The intelligence the new character should have. Encoded as <see cref="int"/>.</summary>
    Intelligence,

    /// <summary>The willpower the new character should have. Encoded as <see cref="int"/>.</summary>
    Willpower,

    /// <summary>The perception the new character should have. Encoded as <see cref="int"/>.</summary>
    Perception,

    /// <summary>The essence the new character should have. Encoded as <see cref="int"/>.</summary>
    Essence,
    #endregion
  }
}
