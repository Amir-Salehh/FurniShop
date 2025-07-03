using Konscious.Security.Cryptography;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace FurniShop.Application.Security
{
    public class PasswordHelper
    {
        public static byte[] HashPassword(string password, byte[] salt)
        {
            var argon2 = new Argon2id(Encoding.UTF8.GetBytes(password))
            {
                Salt = salt,
                DegreeOfParallelism = 4,
                MemorySize = 65536,
                Iterations = 4
            };
            return argon2.GetBytes(32);
        }

        public static string HashPasswordBase64(string password, byte[] salt)
        {
            var hash = HashPassword(password, salt);
            return Convert.ToBase64String(hash);
        }
    }
}
