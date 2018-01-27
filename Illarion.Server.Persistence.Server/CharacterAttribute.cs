using System;

namespace Illarion.Server.Persistence.Server
{
  public class CharacterAttribute
  {
    public Guid CharacterId { get; private set; }
    public Character Character { get; private set; }

    public CharacterAttributeId AttributeId { get; private set; }
    public int Value { get; set; }

    public CharacterAttribute(Character character, CharacterAttributeId attributeId)
    {
      Character = character ?? throw new ArgumentNullException(nameof(character));
      CharacterId = character.CharacterId;
      AttributeId = attributeId;
    }
  }
}
