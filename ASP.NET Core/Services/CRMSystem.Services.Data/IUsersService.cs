namespace CRMSystem.Services
{
    public interface IUsersService
    {
        T GetById<T>(string username, string password);

        void ChangePassword(string username, string newPassword);

        bool IsUsernameUsed(string username);

        bool IsEmailUsed(string email);

        int CountUsers();
    }
}
