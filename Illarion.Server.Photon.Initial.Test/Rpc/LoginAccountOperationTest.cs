using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Illarion.Net.Common;
using Illarion.Net.Common.Operations.Initial;
using Photon.SocketServer;
using Xunit;

namespace Illarion.Server.Photon.Rpc
{
  public sealed class LoginAccountOperationTest
  {
    [Trait("Category", "Networking")]
    [Theory]
    [MemberData(nameof(DecodeOperationRequestTestData))]
    public static void DecodeOperationRequestTest(string accountName, string password, bool isValid, bool annotationIsValid)
    {
      var data = new Dictionary<byte, object>() {
        { (byte)LoginAccountOperationRequestParameterCode.AccountName, accountName },
        { (byte)LoginAccountOperationRequestParameterCode.Password, password },
      };

      var operationRequest = new OperationRequest((byte)InitialOperationCode.LoginAccount, data);
      var operation = new LoginAccountOperation(Protocol.GpBinaryV17, request: operationRequest);

      Assert.NotNull(operation.OperationRequest);
      Assert.Equal((byte)InitialOperationCode.LoginAccount, operation.OperationRequest.OperationCode);
      Assert.Equal(isValid, operation.IsValid);

      if (isValid)
      {
        Assert.Equal(accountName, operation.AccountName);
        Assert.Equal(password, operation.Password);

        try
        {
          Validator.ValidateObject(operation, new ValidationContext(operation), true);
          Assert.True(annotationIsValid);
        }
        catch (ValidationException)
        {
          Assert.False(annotationIsValid);
        }
      }
    }

    public static IEnumerable<object[]> DecodeOperationRequestTestData()
    {
      yield return new object[] { "TestAccount", "VerySecretPassword", true, true };
      yield return new object[] { "TestAccount", "", true, false };
      yield return new object[] { "TestAccount", null, false, false };
      yield return new object[] { "", "VerySecretPassword", true, false };
      yield return new object[] { null, "VerySecretPassword", false, false };
      yield return new object[] { null, null, false, false };
    }
  }
}
