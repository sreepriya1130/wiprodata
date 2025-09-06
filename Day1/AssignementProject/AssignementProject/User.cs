using AssignementProject;

namespace AssignementProject
{
    public class User
    {
        public string Username { get; set; }
        public string HashedPassword { get; private set; }
        public string EncryptedDetails { get; private set; }

        public void Register(string username, string password, string details)
        {
            Username = username;
            HashedPassword = SecurityHelper.HashPassword(password);
            EncryptedDetails = SecurityHelper.EncryptData(details);
            LoggerService.LogInfo($"User '{username}' registered successfully.");
        }

        public bool Authenticate(string username, string password)
        {
            if (Username == username && SecurityHelper.VerifyPassword(password, HashedPassword))
            {
                LoggerService.LogInfo($"User '{username}' logged in successfully.");
                return true;
            }
            LoggerService.LogError("Authentication failed.");
            return false;
        }

        public string GetDecryptedDetails()
        {
            return SecurityHelper.DecryptData(EncryptedDetails);
        }
    }
}
