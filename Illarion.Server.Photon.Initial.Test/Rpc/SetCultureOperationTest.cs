using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using Illarion.Net.Common;
using Illarion.Net.Common.Operations.Initial;
using Photon.SocketServer;
using Xunit;

namespace Illarion.Server.Photon.Rpc
{
  public sealed class SetCultureOperationTest
  {
    [Trait("Category", "Networking")]
    [Theory]
    [MemberData(nameof(DecodeOperationRequestTestData))]
    public static void DecodeOperationRequestTest(string cultureName, int lcid, bool isValid, bool annotationIsValid)
    {
      var data = new Dictionary<byte, object>() {
        { (byte)SetCultureOperationParameterCode.CultureName, cultureName },
      };

      var operationRequest = new OperationRequest((byte)InitialOperationCode.SetCulture, data);
      var operation = new SetCultureOperation(new TestRpcProtocol(), operationRequest);

      Assert.NotNull(operation.OperationRequest);
      Assert.Equal((byte)InitialOperationCode.SetCulture, operation.OperationRequest.OperationCode);
      Assert.Equal(isValid, operation.IsValid);

      if (isValid)
      {
        Assert.Equal(cultureName, operation.CultureName, ignoreCase: true);

        try
        {
          Validator.ValidateObject(operation, new ValidationContext(operation), true);
          Assert.True(annotationIsValid);

          Assert.Equal(lcid, operation.Culture.LCID);
        }
        catch (ValidationException)
        {
          Assert.False(annotationIsValid);
        }
      }
    }

    public static IEnumerable<object[]> DecodeOperationRequestTestData()
    {
      yield return new object[] { "de", CultureInfo.GetCultureInfo("de").LCID, true, true };
      yield return new object[] { "de-DE", CultureInfo.GetCultureInfo("de-DE").LCID, true, true };
      yield return new object[] { "en", CultureInfo.GetCultureInfo("en").LCID, true, true };
      yield return new object[] { "en-US", CultureInfo.GetCultureInfo("en-US").LCID, true, true };
      yield return new object[] { "en-GB", CultureInfo.GetCultureInfo("en-GB").LCID, true, true };
      yield return new object[] { "does-NOT-Exist", CultureInfo.InvariantCulture.LCID, true, true };
      yield return new object[] { "", 0, true, false };
      yield return new object[] { null, 0, false, false };
    }
  }
}
