using System;
using System.Globalization;
using System.Security.Cryptography;

namespace Illarion.Server.Photon
{
  internal static class PasswordHashing
  {
    private const int SaltSize = 24;
    private const int HashSize = 48;

    internal static string GetPasswordHash(string password)
    {
      var salt = new byte[SaltSize];
      var iterationBytes = new byte[2];
      using (var rng = new RNGCryptoServiceProvider())
      {
        rng.GetBytes(salt);
        rng.GetBytes(iterationBytes);
      }

      var iterations = 1000 + (BitConverter.ToInt16(iterationBytes, 0) % 1000);

      var hash = GetPasswordHash(iterations, salt, password);

      return string.Format(
        CultureInfo.InvariantCulture,
        "{0:d}:{1}:{2}",
        iterations,
        Convert.ToBase64String(salt),
        Convert.ToBase64String(hash));
    }

    private static byte[] GetPasswordHash(int iterations, byte[] salt, string password)
    {
      var hashTool = new Rfc2898DeriveBytes(password, salt)
      {
        IterationCount = iterations
      };
      return hashTool.GetBytes(HashSize);
    }

    internal static bool VerifyPasswordHash(string password, string hashedPassword)
    {
      var hashParts = hashedPassword.Split(':');

      var iterations = int.Parse(hashParts[0], NumberStyles.None, CultureInfo.InvariantCulture);
      var originalSalt = Convert.FromBase64String(hashParts[1]);
      var originalHash = Convert.FromBase64String(hashParts[2]);

      var newHash = GetPasswordHash(iterations, originalSalt, password);

      for (int i = 0, k = Math.Min(originalHash.Length, newHash.Length); i < k ; i++)
      {
        if (newHash[i] != originalHash[i])
          return false;
      }
      return true;
    }
  }
}
