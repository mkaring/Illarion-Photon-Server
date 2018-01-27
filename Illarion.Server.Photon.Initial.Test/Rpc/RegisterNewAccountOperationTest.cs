using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Illarion.Net.Common;
using Illarion.Net.Common.Operations.Initial;
using Photon.SocketServer;
using Xunit;

namespace Illarion.Server.Photon.Rpc
{
  public sealed class RegisterNewAccountOperationTest
  {
    [Trait("Category", "Networking")]
    [Theory]
    [MemberData(nameof(DecodeOperationRequestTestData))]
    public static void DecodeOperationRequestTest(string accountName, string email, string password, bool isValid, bool annotationIsValid)
    {
      var data = new Dictionary<byte, object>() {
        { (byte)RegisterNewAccountOperationParameterCode.AccountName, accountName },
        { (byte)RegisterNewAccountOperationParameterCode.EMail, email },
        { (byte)RegisterNewAccountOperationParameterCode.Password, password },
      };

      var operationRequest = new OperationRequest((byte)InitialOperationCode.RegisterNewAccount, data);
      var operation = new RegisterNewAccountOperation(new TestRpcProtocol(), operationRequest);

      Assert.NotNull(operation.OperationRequest);
      Assert.Equal((byte)InitialOperationCode.RegisterNewAccount, operation.OperationRequest.OperationCode);
      Assert.Equal(isValid, operation.IsValid);

      if (isValid)
      {
        Assert.Equal(accountName, operation.AccountName);
        Assert.Equal(email, operation.EMail.ToString(), ignoreCase: true);
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
      yield return new object[] { "TestAccount", "test@example.com", "VerySecretPassword", true, true };
      yield return new object[] { "TestAccount", "broken@mail", "VerySecretPassword", true, false };
      yield return new object[] { "A", "test@example.com", "VerySecretPassword", true, false };
      yield return new object[] { null, "test@example.com", "VerySecretPassword", false, false };
      yield return new object[] { "TestAccount", "test@example.com", "Short", true, false };
      yield return new object[] { "TestAccount", "test@example.com", null, false, false };
      yield return new object[] { "TestAccount", null, "VerySecretPassword", false, false };
    }
  }
}
