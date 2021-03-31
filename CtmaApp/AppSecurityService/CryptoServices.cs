using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
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
            var saltedPassword = password.ToNormalSTR() + salt;
            var computedHash = 
                sha.ComputeHash(
                    Encoding.Unicode
                    .GetBytes(saltedPassword));

            return Convert.ToBase64String(computedHash);
        }
        public static GenericPrincipal LogIn(string username, string password) =>
            LogIn(username, password.ToSecureSTR());
        public static GenericPrincipal LogIn(string username, SecureString password)
        {
            if (!CheckPassword(username, password))
                return null;
            var identity = new GenericIdentity
                (username, "MyAppAuth");
            var principal = new GenericPrincipal
                (identity, Users["username"].Roles);
            return principal;
        }
        public static bool CheckPassword(string username, string password) => 
            CheckPassword(username, password.ToSecureSTR());
        public static bool CheckPassword(string username, SecureString password)
        {
            if (!Users.ContainsKey(username)) return false;
            var user = Users[username];
            var saltedHasedPassword =
                SaltAndHashPassword(password, user.Salt);
            Console.WriteLine($"{saltedHasedPassword} == {user.SaltedHash}");
            return saltedHasedPassword == user.SaltedHash;
        }
        /// <summary>
        /// Converts a common string to Secure String
        /// </summary>
        /// <param name="original">
        /// Original String
        /// </param>
        /// <returns>
        /// SecureString built from it
        /// </returns>
        public static SecureString ToSecureSTR(this string original)
        {
            char[] charArr = original.ToCharArray();
            SecureString result = new SecureString();
            foreach (char c in charArr)
            {
                result.AppendChar(c);
            }
            return result;
        }
        public static string ToNormalSTR(this SecureString original)
        {
            IntPtr unmanagedStr = IntPtr.Zero;
            try
            {
                unmanagedStr =
                    Marshal
                    .SecureStringToGlobalAllocUnicode(original);
                return Marshal.PtrToStringUni(unmanagedStr);

            }
            finally
            {
                Marshal.ZeroFreeGlobalAllocUnicode(unmanagedStr);
            }
        }
    }
}
