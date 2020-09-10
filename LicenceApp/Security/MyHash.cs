using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace LicenceApp
{
   public static class MyHash
    {

        public static byte[] GenerateSaltedHash(byte[] plainText)
        {
            if (plainText == null) { throw new ArgumentNullException("plainText"); }
            if (plainText.Length == 0) { throw new ArgumentException("Length may not be zero", "plainText"); }

            using (HashAlgorithm algorithm = new SHA256Managed())
            {
                byte[] salt = GenerateSalt();
                byte[] saltedText = new byte[plainText.Length + salt.Length];

                plainText.CopyTo(saltedText, 0);
                salt.CopyTo(saltedText, plainText.Length);

                return algorithm.ComputeHash(saltedText);
            }
        }

        private static byte[] GenerateSalt()
        {
            using (RandomNumberGenerator random = new RNGCryptoServiceProvider())
            {
                byte[] salt = new byte[10];
                random.GetNonZeroBytes(salt);
                return salt;
            }
        }
    }
}
