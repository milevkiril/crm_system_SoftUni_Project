using System.Collections.Generic;

namespace CRMSystem.Services
{
    public interface IUsersService
    {
        T GetById<T>(string username);

        void ChangePassword(string username, string newPassword);

        bool IsUsernameUsed(string username);

        bool IsEmailUsed(string email);

        int CountUsers();

        IEnumerable<T> GetAll<T>();
    }
}
