using System;
using System.Collections.Generic;
using System.Numerics;

namespace Illarion.Server.Persistence.Server
{
  public class Character
  {
    private float[] _location;

    public Character(Guid accountId, string name, RaceType raceType, int dayOfBirth, int monthOfBirth, int yearOfBirth)
    {
      _location = new float[3];
      AccountId = accountId;
      Name = name;
      RaceType = RaceType ?? throw new ArgumentNullException(nameof(raceType));
      DayOfBirth = dayOfBirth;
      MonthOfBirth = monthOfBirth;
      YearOfBirth = yearOfBirth;
    }

    public Guid AccountId { get; private set; }
    public Guid CharacterId { get; private set; }
    public string Name { get; private set; }
    public Guid RaceTypeId { get; set; }
    public CharacterStatus Status { get; set; }
    public Vector3 Location {
      get => new Vector3(_location[0], _location[1], _location[2]);
      set => value.CopyTo(_location);
    }

    #region birthday
    public int DayOfBirth { get; private set; }
    public int MonthOfBirth { get; private set; }
    public int YearOfBirth { get; private set; }
    #endregion

    #region body properties
    public double BodyHeight { get; set; }
    public double BodyWeight { get; set; }
    public double BodyShape { get; set; }

    public int HairColor1 { get; set; }
    public int HairColor2 { get; set; }
    public int SkinColor1 { get; set; }
    public int SkinColor2 { get; set; }
    #endregion

    public List<CharacterAttribute> Attributes { get; }
    public RaceType RaceType { get; set; }
  }
}
