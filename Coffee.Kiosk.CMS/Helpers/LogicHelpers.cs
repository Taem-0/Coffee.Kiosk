using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Coffee.Kiosk.CMS.Helpers
{
    internal class LogicHelpers
    {

        private const string DEFAULT_PASSWORD = "CoffeeKiosk@123";
        //Bad practice I think

        public static string GenerateSalt()
        {
            byte[] saltBytes = new byte[32];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(saltBytes);
            }
            return Convert.ToBase64String(saltBytes);
        }

        public static string HashPassword(string password, string salt)
        {
            using (var sha256 = SHA256.Create())
            {
                var saltedPassword = password + salt;
                var bytes = Encoding.UTF8.GetBytes(saltedPassword);
                var hash = sha256.ComputeHash(bytes);
                return Convert.ToBase64String(hash);
            }
        }

        public static (string hash, string salt) GenerateDefaultPassword()
        {
            var salt = GenerateSalt();
            var hash = HashPassword(DEFAULT_PASSWORD, salt);
            return (hash, salt);
        }

        public static bool VerifyPassword(string password, string storedHash, string storedSalt)
        {
            var hashToVerify = HashPassword(password, storedSalt);
            return hashToVerify == storedHash;
        }

        public static string GetTemporaryPasswordDisplay()
        {
            return DEFAULT_PASSWORD;
        }

    }
}
