using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Security.Cryptography;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CtmaApp.Models;

namespace CtmaApp.AppSecurityService
{
    public static class CryptoServices
    {
        //TODO: using temp dic for users
        private static Dictionary<string, UserAccount> Users = new Dictionary<string, UserAccount>();
        public static UserAccount Register(string username, SecureString password, string[] roles)
        {
            var rng = RandomNumberGenerator.Create();
            var saltBytes = new byte[16];
            rng.GetBytes(saltBytes);
            var saltText = Convert.ToBase64String(saltBytes);
            var saltedHashedPass = 
                SaltAndHashPassword(password, saltText);
            var user = new UserAccount
            {
                UserName = username,
                Salt = saltText,
                SaltedHash = saltedHashedPass,
                Roles = roles
            };
            //TODO: Add new user to EF context;
            Users.Add(user.UserName, user);
            return user;
        }

        private static string SaltAndHashPassword(SecureString password, string salt)
        {
            var sha = SHA256.Create();
            var saltedPassword = password + salt;
            var computedHash = 
                sha.ComputeHash(
                    Encoding.Unicode
                    .GetBytes(saltedPassword));

            return Convert.ToBase64String(computedHash);
        }

        public static void LogIn(string username, SecureString password)
        {
            if (!CheckPassword(username, password))
                return;
            var identity = new GenericIdentity
                (username, "MyAppAuth");
            var principal = new GenericPrincipal
                (identity, Users["username"].Roles);
            Thread.CurrentPrincipal = principal;
        }

        public static bool CheckPassword(string username, SecureString password)
        {
            if (!Users.ContainsKey(username)) return false;
            var user = Users[username];
            var saltedHasedPassword =
                SaltAndHashPassword(password, user.Salt);
            return saltedHasedPassword == user.SaltedHash;
        }
    }
}
