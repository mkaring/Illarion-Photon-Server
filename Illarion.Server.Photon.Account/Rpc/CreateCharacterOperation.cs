using Illarion.Net.Common.Operations.Account;
using Photon.SocketServer;
using Photon.SocketServer.Rpc;
using System;
using System.ComponentModel.DataAnnotations;

namespace Illarion.Server.Photon.Rpc
{
  internal sealed class CreateCharacterOperation : Operation
  {
    public CreateCharacterOperation(IRpcProtocol protocol, OperationRequest request) : base(protocol, request)
    {
    }

    [DataMember(Name = nameof(Preview), Code = (byte)CreateCharacterOperationRequestParameterCode.Preview, IsOptional = true)]
    public bool Preview { get; set; }

    [DataMember(Name = nameof(CharacterName), Code = (byte)CreateCharacterOperationRequestParameterCode.CharacterName)]
    [Required]
    public string CharacterName { get; set; }

    [DataMember(Name = nameof(Race), Code = (byte)CreateCharacterOperationRequestParameterCode.Race)]
    [Required]
    public int Race { get; set; }

    [DataMember(Name = nameof(RaceType), Code = (byte)CreateCharacterOperationRequestParameterCode.RaceType)]
    [Required]
    public int RaceType { get; set; }

    #region birthday
    [DataMember(Name = nameof(DayOfBirth), Code = (byte)CreateCharacterOperationRequestParameterCode.DayOfBirth)]
    [Required]
    public int DayOfBirth { get; set; }

    [DataMember(Name = nameof(MonthOfBirth), Code = (byte)CreateCharacterOperationRequestParameterCode.MonthOfBirth)]
    [Required]
    public int MonthOfBirth { get; set; }

    [DataMember(Name = nameof(YearOfBirth), Code = (byte)CreateCharacterOperationRequestParameterCode.YearOfBirth)]
    [Required]
    public int YearOfBirth { get; set; }
    #endregion

    #region body properties
    [DataMember(Name = nameof(BodyHeight), Code = (byte)CreateCharacterOperationRequestParameterCode.BodyHeight)]
    [Required]
    public double BodyHeight { get; set; }

    [DataMember(Name = nameof(BodyWeight), Code = (byte)CreateCharacterOperationRequestParameterCode.BodyWeight)]
    [Required]
    public double BodyWeight { get; set; }

    [DataMember(Name = nameof(BodyShape), Code = (byte)CreateCharacterOperationRequestParameterCode.BodyShape)]
    [Required]
    public double BodyShape { get; set; }

    [DataMember(Name = nameof(HairColor1), Code = (byte)CreateCharacterOperationRequestParameterCode.HairColor1)]
    [Required]
    public int HairColor1 { get; set; }

    [DataMember(Name = nameof(HairColor2), Code = (byte)CreateCharacterOperationRequestParameterCode.HairColor2)]
    [Required]
    public int HairColor2 { get; set; }

    [DataMember(Name = nameof(SkinColor1), Code = (byte)CreateCharacterOperationRequestParameterCode.SkinColor1)]
    [Required]
    public int SkinColor1 { get; set; }

    [DataMember(Name = nameof(SkinColor2), Code = (byte)CreateCharacterOperationRequestParameterCode.SkinColor2)]
    [Required]
    public int SkinColor2 { get; set; }
    #endregion

    #region Parameters
    [DataMember(Name = nameof(Agility), Code = (byte)CreateCharacterOperationRequestParameterCode.Agility)]
    [Required]
    public int Agility { get; set; }

    [DataMember(Name = nameof(Constitution), Code = (byte)CreateCharacterOperationRequestParameterCode.Constitution)]
    [Required]
    public int Constitution { get; set; }

    [DataMember(Name = nameof(Dexterity), Code = (byte)CreateCharacterOperationRequestParameterCode.Dexterity)]
    [Required]
    public int Dexterity { get; set; }

    [DataMember(Name = nameof(Essence), Code = (byte)CreateCharacterOperationRequestParameterCode.Essence)]
    [Required]
    public int Essence { get; set; }

    [DataMember(Name = nameof(Intelligence), Code = (byte)CreateCharacterOperationRequestParameterCode.Intelligence)]
    [Required]
    public int Intelligence { get; set; }

    [DataMember(Name = nameof(Perception), Code = (byte)CreateCharacterOperationRequestParameterCode.Perception)]
    [Required]
    public int Perception { get; set; }

    [DataMember(Name = nameof(Strength), Code = (byte)CreateCharacterOperationRequestParameterCode.Strength)]
    [Required]
    public int Strength { get; set; }

    [DataMember(Name = nameof(Willpower), Code = (byte)CreateCharacterOperationRequestParameterCode.Willpower)]
    [Required]
    public int Willpower { get; set; }
    #endregion
  }
}
