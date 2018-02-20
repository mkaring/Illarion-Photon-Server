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
