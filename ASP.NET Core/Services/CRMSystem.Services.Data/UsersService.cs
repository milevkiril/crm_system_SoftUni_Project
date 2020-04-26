namespace CRMSystem.Services.Data
{
    using CRMSystem.Data.Common.Repositories;
    using CRMSystem.Data.Models;
    using CRMSystem.Services.Mapping;
    using Microsoft.AspNetCore.Identity;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Cryptography;
    using System.Text;

    public class UsersService : IUsersService
    {
        private readonly IDeletableEntityRepository<ApplicationUser> usersRepository;

        public UsersService(IDeletableEntityRepository<ApplicationUser> usersRepository)
        {
            this.usersRepository = usersRepository;
        }

        public void ChangePassword(string username, string newPassword)
        {
            throw new System.NotImplementedException();
        }

        public int CountUsers()
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<T> GetAll<T>()
        {
            IQueryable<ApplicationUser> users = this.usersRepository
                .All()
                .OrderByDescending(x => x.CreatedOn);

            return users.To<T>().ToList();
        }

        public T GetById<T>(string username)
        {
            var user = this.usersRepository
                .All()
                .Where(x => x.UserName == username)
                .To<T>()
                .FirstOrDefault();
            return user;
        }

        public bool IsEmailUsed(string email)
        {
            throw new System.NotImplementedException();
        }

        public bool IsUsernameUsed(string username)
        {
            throw new System.NotImplementedException();
        }

        private string Hash(string input)
        {
            if (input == null)
            {
                return null;
            }

            var crypt = new SHA256Managed();
            var hash = new StringBuilder();
            byte[] crypto = crypt.ComputeHash(Encoding.UTF8.GetBytes(input));
            foreach (byte theByte in crypto)
            {
                hash.Append(theByte.ToString("x2"));
            }

            return hash.ToString();
        }
    }
}
