using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using CtmaApp.AppSecurityService;
using NUnit.Framework;

namespace CtmaAppTests.AppSecurityServiceTests
{
    public class CryptoServicesTests
    {
        [SetUp]
        public void SetUp()
        {

        }
        [Test]
        public void RegisterTest()
        {
            //Arrange
            string myName = "MomiCat";
            SecureString myPass = new SecureString();
            myPass.AppendChar('P');
            myPass.AppendChar('@');
            myPass.AppendChar('s');
            myPass.AppendChar('$');
            myPass.AppendChar('w');
            myPass.AppendChar('0');
            myPass.AppendChar('r');
            myPass.AppendChar('D');

            //Act
            var user = CryptoServices.Register(myName, myPass, new string[] { "Cute_Cat" });

            //Assert
        }
    }
}
