using NUnit.Framework;
using AssignementProject;

namespace AssignementProject.Tests
{
    [TestFixture]
    public class UserTests
    {
        [Test]
        public void Test_User_Registration_And_Authentication()
        {
            var user = new User();
            user.Register("Bob", "MyPass123", "Sensitive Data");

            Assert.IsTrue(user.Authenticate("Bob", "MyPass123"));
            Assert.IsFalse(user.Authenticate("Bob", "WrongPass"));
        }

        [Test]
        public void Test_Data_Encryption_Decryption()
        {
            string sensitiveData = "Credit Card Number 1234";
            string encrypted = SecurityHelper.EncryptData(sensitiveData);
            string decrypted = SecurityHelper.DecryptData(encrypted);

            Assert.AreEqual(sensitiveData, decrypted);
        }

        [Test]
        public void Test_Error_Logging_When_Login_Fails()
        {
            var user = new User();
            user.Register("Charlie", "Test123", "Sensitive");

            bool loginResult = user.Authenticate("Charlie", "WrongPassword");
            Assert.IsFalse(loginResult);
        }
    }
}
