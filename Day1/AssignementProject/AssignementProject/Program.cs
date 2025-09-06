using AssignementProject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignementProject
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                User user = new User();
                user.Register("Alice", "SecurePass123", "Sensitive Info: Alice's Address");

                bool loginSuccess = user.Authenticate("Alice", "SecurePass123");
                Console.WriteLine("Login Successful: " + loginSuccess);

                Console.WriteLine("Decrypted Details: " + user.GetDecryptedDetails());
            }
            catch (Exception ex)
            {
                LoggerService.LogError($"Unhandled Exception: {ex.Message}");
            }
        }
    }
}
