using System.Collections.Generic;
using Xunit;

namespace Illarion.Server.Photon
{
  public sealed class PasswordHashingTest
  {
    [Trait("Category", "Security")]
    [Theory]
    [MemberData(nameof(HashingRoundTripTestData))]
    public void HashingRoundTripTest(string password)
    {
      var hashedPassword = PasswordHashing.GetPasswordHash(password);

      Assert.True(PasswordHashing.VerifyPasswordHash(password, hashedPassword));
    }

    public static IEnumerable<object[]> HashingRoundTripTestData()
    {
      yield return new object[] { @"sXjNVG9QEsp2pO1Q" };
      yield return new object[] { @"K#%e\Lcrf-)l1OZ|" };
      yield return new object[] { @"b@^^<oPeUcVr<cp:" };
      yield return new object[] { @";7\""J6D9%Qfd[+=9" };
    }
  }
}
