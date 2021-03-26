using Microsoft.VisualStudio.TestTools.UnitTesting;
using SecureApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecureApp.Tests
{
    [TestClass()]
    public class ProtectorTests
    {
        [TestMethod()]
        public void EncryptTest()
        {
            //Arrange
            string messageToEncrypt =
                "There is a fox on the mountain of the tree where the fox is picking cottons";
            string pass = "p@$sw0rd";

            //Act
            string Encrypted = Protector.Encrypt(messageToEncrypt, pass);
            Console.WriteLine("The encrypted message is:");
            Console.WriteLine(Encrypted);

            string Decrypted = Protector.Decrypt(Encrypted, pass);

            //Assert
            Assert.AreEqual(
                messageToEncrypt,
                Decrypted);
        }

        [TestMethod()]
        public void RegisterTest()
        {
            var alice = Protector.Register("alice", "mypass");
            Console.WriteLine($"Name: {alice.Name}");
            Console.WriteLine($"Salt: {alice.Salt}");
            Console.WriteLine($"SaltedHash: {alice.SaltedHashedPassword}");

            Assert.IsTrue(Protector.CheckPassword("alice", "mypass"));
            Assert.IsFalse(Protector.CheckPassword("alice", "notpass"));
        }
    }
}