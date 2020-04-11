using CRMSystem.Data.Common.Repositories;
using CRMSystem.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CRMSystem.Services.Data
{
    public class RolesService
    {
        private readonly IDeletableEntityRepository<ApplicationRole> rolesRepository;

        public RolesService(IDeletableEntityRepository<ApplicationRole> rolesRepository)
        {
            this.rolesRepository = rolesRepository;
        }

        public async Task<string> CreateAsync(string name)
        {
            var role = new ApplicationRole
            {
                Name = name,
            };

            await this.rolesRepository.AddAsync(role);
            await this.rolesRepository.SaveChangesAsync();
            return role.Id;
        }
    }
}
