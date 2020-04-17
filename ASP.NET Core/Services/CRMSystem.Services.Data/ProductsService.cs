namespace CRMSystem.Services.Data
{
    using CRMSystem.Data.Common.Repositories;
    using CRMSystem.Data.Models;
    using Microsoft.AspNetCore.Identity;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class ProductsService : IProductService
    {
        private readonly IDeletableEntityRepository<Product> productRepository;
        private readonly UserManager<ApplicationUser> userManager;

        public ProductsService(
            IDeletableEntityRepository<Product> productRepository,
            UserManager<ApplicationUser> userManager)
        {
            this.productRepository = productRepository;
            this.userManager = userManager;
        }

        public async Task<int> CreateAsync(string productName, string description, string priceInput, string userId)
        {
            var user = await this.userManager.FindByIdAsync(userId);
            var userName = user.UserName;
            decimal priceToConvert = decimal.Parse(priceInput);


            var product = new Product
            {
                Name = productName,
                UserId = userId,
                Description = description,
                Price = priceToConvert,
            };

            await this.productRepository.AddAsync(product);
            await this.productRepository.SaveChangesAsync();
            return product.Id;
        }

        public IEnumerable<T> GetAll<T>()
        {
            throw new System.NotImplementedException();
        }

        public T GetById<T>(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}
