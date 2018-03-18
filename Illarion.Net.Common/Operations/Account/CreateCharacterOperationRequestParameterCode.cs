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

    /// <summary>The race of the character. Encoded as <see cref="int"/>.</summary>
    Race,

    /// <summary>
    /// The sub-type of the race. In most cases this should be the gender. Encoded as <see cref="int"/>.
    /// </summary>
    RaceType,

    #region birthday
    /// <summary>The day within the month the character was born. Encoded as <see cref="int"/>.</summary>
    /// <remarks>
    /// The first day of the month has the value <c>1</c>. The value is expected to be within the constraints of the
    /// calendar of Illarion. Every month except Mas has 30 days. Mas has 5. Exceeding the values will result in the
    /// character creation of the rejected.
    /// </remarks>
    DayOfBirth,

    /// <summary>The month within the year the character was born. Encoded as <see cref="int"/>.</summary>
    /// <remarks>
    ///   <list type="table">
    ///     <listheader>
    ///       <term>Value</term>
    ///       <description>Name of the month</description>
    ///     </listheader>
    ///     <item><term>1</term><description>Elos</description></item>
    ///     <item><term>2</term><description>Tanos</description></item>
    ///     <item><term>3</term><description>Zhas</description></item>
    ///     <item><term>4</term><description>Ushos</description></item>
    ///     <item><term>5</term><description>Siros</description></item>
    ///     <item><term>6</term><description>Ronas</description></item>
    ///     <item><term>7</term><description>Brás</description></item>
    ///     <item><term>8</term><description>Eldas</description></item>
    ///     <item><term>9</term><description>Irmas</description></item>
    ///     <item><term>10</term><description>Malas</description></item>
    ///     <item><term>11</term><description>Findos</description></item>
    ///     <item><term>12</term><description>Olos</description></item>
    ///     <item><term>13</term><description>Adras</description></item>
    ///     <item><term>14</term><description>Naras</description></item>
    ///     <item><term>15</term><description>Chos</description></item>
    ///     <item><term>16</term><description>Mas</description></item>
    ///   </list>
    /// </remarks>
    MonthOfBirth,

    /// <summary>
    /// The year the character was born. Encoded as <see cref="int"/>. May be negative.
    /// The year is in the calendar of Illarion.
    /// </summary>
    YearOfBirth,
    #endregion

    #region body properties
    /// <summary>The height of the characters. Measured in meter. Encoded as <see cref="double"/>.</summary>
    BodyHeight,

    /// <summary>The weight of the characters. Measured in kilo gramms. Encoded as <see cref="double"/>.</summary>
    BodyWeight,

    /// <summary>
    /// Additional shape value that is used to differentiate if the body shape leans to be fat or muscular.
    /// Encoded as <see cref="double"/>.
    /// </summary>
    BodyShape,

    /// <summary>First hair color. RGB color encoded as <see cref="int" />.</summary>
    HairColor1,

    /// <summary>Second hair color. RGB color encoded as <see cref="int" />.</summary>
    HairColor2,

    /// <summary>First skin color. RGB color encoded as <see cref="int" />.</summary>
    SkinColor1,

    /// <summary>Second skin color. RGB color encoded as <see cref="int" />.</summary>
    SkinColor2,
    #endregion

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
