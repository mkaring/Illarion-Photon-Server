using System;
using System.Collections.Generic;
using System.Linq;
using Illarion.Net.Common;
using Illarion.Net.Common.Operations.Account;
using Illarion.Server.Persistence;
using Illarion.Server.Persistence.Server;
using Illarion.Server.Photon.Properties;
using Illarion.Server.Photon.Rpc;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.DependencyInjection;
using Photon.SocketServer;

namespace Illarion.Server.Photon
{
  public sealed class AccountOperationHandler : PlayerPeerOperationHandler, IAccountOperationHandler
  {
    private readonly IServiceProvider _services;

    public AccountOperationHandler(IServiceProvider services) : base(services) =>
      _services = services ?? throw new ArgumentNullException(nameof(services));

    protected override void OnDisconnect(PlayerPeerBase peer)
    {
    }

    protected override OperationResponse OnOperationRequest(PlayerPeerBase peer, OperationRequest operationRequest, SendParameters sendParameters)
    {
      if (peer == null) throw new ArgumentNullException(nameof(peer));
      if (operationRequest == null) throw new ArgumentNullException(nameof(operationRequest));

      switch ((AccountOperationCode)operationRequest.OperationCode)
      {
        case AccountOperationCode.CreateCharacter:
          return OnCreateCharacterOperationRequest(peer, operationRequest);
        case AccountOperationCode.ListCharacters:
          return OnListCharactersOperationRequest(peer, operationRequest);
        case AccountOperationCode.GetCharacter:
          return OnGetCharacterOperationRequest(peer, operationRequest);
        case AccountOperationCode.LoginCharacter:
          return OnLoginCharacterOperationRequest(peer, operationRequest);
        case AccountOperationCode.LogoutAccount:
          return OnLogoutAccountOperationRequest(peer, operationRequest);
      }

      return InvalidOperation(operationRequest);
    }

    private OperationResponse OnListCharactersOperationRequest(PlayerPeerBase peer, OperationRequest operationRequest)
    {
      IQueryable<Character> characters = _services.GetRequiredService<ServerContext>().Characters.
        Where(c => c.AccountId == peer.Account.AccountId);

      var responseData = new ListCharactersReponse() { CharacterList = new List<OperationResponse>() };

      foreach (Character character in characters)
      {
        responseData.CharacterList.Add(GetReponseForCharacter((byte)AccountOperationCode.GetCharacter, character));
      }

      return new OperationResponse(operationRequest.OperationCode)
      {
        ReturnCode = (byte)GetCharacterOperationReturnCode.Success,
        Parameters = responseData.ToDictionary()
      };
    }

    private OperationResponse OnGetCharacterOperationRequest(PlayerPeerBase peer, OperationRequest operationRequest)
    {
      var operation = new GetCharacterOperation(peer.Protocol, operationRequest);
      if (operation.IsValid)
      {
        Character matchingCharacter = _services.GetRequiredService<ServerContext>().Characters.
          Where(c => c.AccountId == peer.Account.AccountId && c.CharacterId == operation.CharacterId).
          FirstOrDefault();
        if (matchingCharacter != null)
        {
          return GetReponseForCharacter(operationRequest.OperationCode, matchingCharacter);
        }
        return new OperationResponse(operationRequest.OperationCode) { ReturnCode = (byte)GetCharacterOperationReturnCode.DoesNotExist };
      }
      else
      {
        return MalformedRequestResponse(operationRequest, operation);
      }
    }

    private static OperationResponse GetReponseForCharacter(byte operationCode, Character character)
    {
      var responseData = new GetCharacterReponse()
      {
        CharacterId = character.CharacterId,
        CharacterName = character.Name,
        CharacterStatus = (character.Status == CharacterStatus.Default) ? 0 : 1
      };

      return new OperationResponse(operationCode)
      {
        ReturnCode = (byte)GetCharacterOperationReturnCode.Success,
        Parameters = responseData.ToDictionary()
      };
    }

    private OperationResponse OnLoginCharacterOperationRequest(PlayerPeerBase peer, OperationRequest operationRequest)
    {
      var operation = new LoginCharacterOperation(peer.Protocol, operationRequest);
      if (operation.IsValid)
      {
        Character matchingCharacter = _services.GetRequiredService<ServerContext>().Characters.
          Where(c => c.AccountId == peer.Account.AccountId && c.CharacterId == operation.CharacterId).
          FirstOrDefault();
        if (matchingCharacter != null)
        {
          switch (matchingCharacter.Status)
          {
            case CharacterStatus.Default:
              peer.Character = matchingCharacter;
              // TODO: Spawn the character in the world
              return new OperationResponse(operationRequest.OperationCode) { ReturnCode = (byte)LoginCharacterOperationReturnCode.Success };
            case CharacterStatus.Blocked:
              return new OperationResponse(operationRequest.OperationCode) { ReturnCode = (byte)LoginCharacterOperationReturnCode.Blocked };
          }
        }
        return new OperationResponse(operationRequest.OperationCode) { ReturnCode = (byte)LoginCharacterOperationReturnCode.DoesNotExist };
      }
      else
      {
        return MalformedRequestResponse(operationRequest, operation);
      }
    }

    private OperationResponse OnLogoutAccountOperationRequest(PlayerPeerBase peer, OperationRequest operationRequest)
    {
      peer.Account = null;
      peer.SetCurrentOperationHandler(_services.GetRequiredService<IInitialOperationHandler>());
      return new OperationResponse(operationRequest.OperationCode) { ReturnCode = (byte)LogoutAccountOperationReturnCode.Success };
    }

    private OperationResponse OnCreateCharacterOperationRequest(PlayerPeerBase peer, OperationRequest operationRequest)
    {
      var operation = new CreateCharacterOperation(peer.Protocol, operationRequest);
      if (operation.IsValid)
      {
        using (ServerContext serverCtx = _services.GetRequiredService<ServerContext>())
        {
          var anyCharacterWithSameName = serverCtx.Characters.Where(c => c.Name == operation.CharacterName).Any();
          if (anyCharacterWithSameName)
          {
            return new OperationResponse(operationRequest.OperationCode)
            {
              ReturnCode = (byte)CreateCharacterOperationReturnCode.CreationFailed,
              Parameters = new CreateCharacterReponse()
              {
                CharacterId = Guid.Empty,
                InvalidFields = new List<byte>() { (byte)CreateCharacterOperationRequestParameterCode.CharacterName },
                InvalidParamterMessages = new List<string>() { Resources.CharacterNameAlreadyUsed }
              }.ToDictionary()
            };
          }

          RaceType raceType = serverCtx.RaceTypes.Where(rt => rt.RaceTypeId == operation.RaceType && rt.RaceId == operation.Race).SingleOrDefault();
          if (raceType == null)
          {
            return new OperationResponse(operationRequest.OperationCode)
            {
              ReturnCode = (byte)CreateCharacterOperationReturnCode.CreationFailed,
              Parameters = new CreateCharacterReponse()
              {
                CharacterId = Guid.Empty,
                InvalidFields = new List<byte>() { (byte)CreateCharacterOperationRequestParameterCode.Race, (byte)CreateCharacterOperationRequestParameterCode.RaceType },
                InvalidParamterMessages = new List<string>() { Resources.CharacterRaceTypeNotFound }
              }.ToDictionary()
            };
          }

          if (operation.Preview)
          {
            return new OperationResponse(operationRequest.OperationCode)
            {
              ReturnCode = (byte)CreateCharacterOperationReturnCode.CreationPossible,
              Parameters = new CreateCharacterReponse()
              {
                CharacterId = Guid.Empty,
                InvalidFields = new List<byte>(),
                InvalidParamterMessages = new List<string>()
              }.ToDictionary()
            };
          }
          else
          {
            EntityEntry<Character> newCharacter;
            using (IDbContextTransaction transaction = serverCtx.Database.BeginTransaction())
            {
              newCharacter = serverCtx.Characters.Add(
                new Character(peer.Account.AccountId, operation.CharacterName, raceType, operation.DayOfBirth, operation.MonthOfBirth, operation.YearOfBirth)
                {
                  Status = CharacterStatus.Default,
                  BodyWeight = operation.BodyWeight,
                  BodyHeight = operation.BodyHeight,
                  BodyShape = operation.BodyShape,
                  HairColor1 = operation.HairColor1,
                  HairColor2 = operation.HairColor2,
                  SkinColor1 = operation.SkinColor1,
                  SkinColor2 = operation.SkinColor2
                });
              newCharacter.Entity.Attributes.Add(new CharacterAttribute(CharacterAttributeId.Agility) { Value = operation.Agility });
              newCharacter.Entity.Attributes.Add(new CharacterAttribute(CharacterAttributeId.Constitution) { Value = operation.Constitution });
              newCharacter.Entity.Attributes.Add(new CharacterAttribute(CharacterAttributeId.Dexterity) { Value = operation.Dexterity });
              newCharacter.Entity.Attributes.Add(new CharacterAttribute(CharacterAttributeId.Essence) { Value = operation.Essence });
              newCharacter.Entity.Attributes.Add(new CharacterAttribute(CharacterAttributeId.Intelligence) { Value = operation.Intelligence });
              newCharacter.Entity.Attributes.Add(new CharacterAttribute(CharacterAttributeId.Perception) { Value = operation.Perception });
              newCharacter.Entity.Attributes.Add(new CharacterAttribute(CharacterAttributeId.Strength) { Value = operation.Strength });
              newCharacter.Entity.Attributes.Add(new CharacterAttribute(CharacterAttributeId.Willpower) { Value = operation.Willpower });

              serverCtx.SaveChanges();
              transaction.Commit();
            }

            return new OperationResponse(operationRequest.OperationCode)
            {
              ReturnCode = (byte)CreateCharacterOperationReturnCode.Success,
              Parameters = new CreateCharacterReponse()
              {
                CharacterId = newCharacter.Entity.CharacterId,
                InvalidFields = new List<byte>(),
                InvalidParamterMessages = new List<string>()
              }.ToDictionary()
            };
          }
        }
      }
      else
      {
        return MalformedRequestResponse(operationRequest, operation);
      }
    }
  }
}
