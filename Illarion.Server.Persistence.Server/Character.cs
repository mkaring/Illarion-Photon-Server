using System;
using System.Collections.Generic;

namespace Illarion.Server.Persistence.Server
{
  public class Character
  {
    public Guid AccountId { get; private set; }
    public Guid CharacterId { get; private set; }
    public string Name { get; private set; }
    public CharacterStatus Status { get; set; }

    public List<CharacterAttribute> Attributes { get; }
  }
}
