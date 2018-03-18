using System.Collections.Generic;

namespace Illarion.Server.Persistence.Server
{
  public class Race
  {
    public Race(int raceId) => RaceId = raceId;

    public int RaceId { get; private set; }
    public bool IsPlayerRace { get; set; } = false;
    public List<RaceType> RaceTypes { get; }
  }
}
