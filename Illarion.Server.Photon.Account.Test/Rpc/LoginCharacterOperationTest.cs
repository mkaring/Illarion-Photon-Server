using System;
using System.Collections.Generic;
using Illarion.Net.Common;
using Illarion.Net.Common.Operations.Account;
using Photon.SocketServer;
using Xunit;

namespace Illarion.Server.Photon.Rpc
{
  public sealed class LoginCharacterOperationTest
  {
    [Trait("Category", "Networking")]
    [Theory]
    [MemberData(nameof(DecodeOperationRequestTestData))]
    public static void DecodeOperationRequestTest(Guid characterId, bool isValid)
    {
      var data = new Dictionary<byte, object>() {
        { (byte)LoginCharacterOperationParameterCode.CharacterId, characterId },
      };

      var operationRequest = new OperationRequest((byte)AccountOperationCode.LoginCharacter, data);
      var operation = new LoginCharacterOperation(Protocol.GpBinaryV17, operationRequest);

      Assert.NotNull(operation.OperationRequest);
      Assert.Equal((byte)AccountOperationCode.LoginCharacter, operation.OperationRequest.OperationCode);
      Assert.Equal(isValid, operation.IsValid);

      if (isValid)
      {
        Assert.Equal(characterId, operation.CharacterId);
      }
    }

    public static IEnumerable<object[]> DecodeOperationRequestTestData()
    {
      unchecked
      {
        yield return new object[] { new Guid(0xddd8f46, 0xa72, 0x4b4a, new byte[] { 0x9d, 0x4a, 0x2d, 0xeb, 0xb7, 0x17, 0x16, 0x1 }), true };
        yield return new object[] { Guid.Empty, true };
      }
    }
  }
}
