using System;
using System.Collections.Generic;

namespace Illarion.Server.Persistence.Server
{
  public class RaceType
  {
    public RaceType(Race race, int raceTypeId)
    {
      Race = race ?? throw new ArgumentNullException(nameof(race));
      RaceId = race.RaceId;
      RaceTypeId = raceTypeId;
    }
    public Guid Id { get; private set; }
    public int RaceId { get; private set; }
    public int RaceTypeId { get; private set; }
    public bool IsPlayerRaceType { get; set; } = false;


    public Race Race { get; private set; }
    public IEnumerable<Character> Characters { get; }
  }
}
