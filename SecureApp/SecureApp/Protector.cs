using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SecureApp
{
    public static class Protector
    {
        private static readonly byte[] salt =
            new byte[16] { 196, 205, 128, 10, 160, 200, 255, 107, 3, 52, 41, 237, 99, 6, 114, 97 };
        private static readonly int iterations = 2000;

        public static string Encrypt(string plain, string password)
        {
            byte[] encryptedBytes;
            byte[] plainBytes = Encoding.Unicode.GetBytes(plain);

            var aes = Aes.Create();
            var pbkdf2 = 
                new Rfc2898DeriveBytes(password, salt, iterations);
            aes.Key = pbkdf2.GetBytes(32);
            aes.IV = pbkdf2.GetBytes(16);
            using (var ms = new MemoryStream())
            {
                using (var cs = new CryptoStream(ms, aes.CreateEncryptor(), CryptoStreamMode.Write))
                {
                    cs.Write(plainBytes, 0, plainBytes.Length);
                }
                encryptedBytes = ms.ToArray();
            }

            return Convert.ToBase64String(encryptedBytes);
        }

        public static string Decrypt(string cryptoText, string password)
        {
            byte[] plain;
            byte[] cryptoBytes = Convert.FromBase64String(cryptoText);
            var aes = Aes.Create();
            var pbkdf2 = new Rfc2898DeriveBytes(password, salt, iterations);
            aes.Key = pbkdf2.GetBytes(32);
            aes.IV = pbkdf2.GetBytes(16);
            using (var ms = new MemoryStream())
            {
                using (var cs = new CryptoStream(
                    ms, aes.CreateDecryptor(),
                    CryptoStreamMode.Write))
                {
                    cs.Write(cryptoBytes, 0, cryptoBytes.Length);
                }
                plain = ms.ToArray();
            }
            return Encoding.Unicode.GetString(plain);
        }

        private static Dictionary<string, User> Users = new Dictionary<string, User>();

        public static User Register(string username, string password, string[] roles = null)
        {
            var rng = RandomNumberGenerator.Create();
            var saltBytes = new byte[16];
            rng.GetBytes(saltBytes);

            var saltText = Convert.ToBase64String(saltBytes);

            var saltedHashedpassword =
                SaltAndHashPassword(password, saltText);

            var user = new User
            {
                Name = username,
                Salt = saltText,
                SaltedHashedPassword = saltedHashedpassword,
                Roles = roles
            };
            Users.Add(user.Name, user);
            return user;
        }

        public static bool CheckPassword(
            string username, string password)
        {
            if (!Users.ContainsKey(username)) return false;
            var user = Users[username];
            var saltedhashedPassword =
                SaltAndHashPassword(password, user.Salt);
            return saltedhashedPassword == user.SaltedHashedPassword;
        }


        private static string SaltAndHashPassword(string password, string salt)
        {
            var sha = SHA256.Create();
            var saltedPassword = password + salt;
            var computedHash = sha.ComputeHash(Encoding.Unicode.GetBytes(saltedPassword));

            return Convert.ToBase64String(computedHash);
        }

        public static void LogIn(string username, string password)
        {
            if (CheckPassword(username, password))
            {
                var identity = new GenericIdentity(username, "MyAppAuth");
                var principal = new GenericPrincipal(
                    identity, Users[username].Roles);
                Thread.CurrentPrincipal = principal;
            }
        }
    }
}
