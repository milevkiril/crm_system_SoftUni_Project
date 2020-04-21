namespace CRMSystem.Services.Data
{
    using CRMSystem.Data.Common.Repositories;
    using CRMSystem.Data.Models;
    using CRMSystem.Services.Mapping;
    using Microsoft.AspNetCore.Identity;
    using System;
    using System.Collections.Generic;
    using System.Linq;
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
            //decimal priceToConvert = decimal.Parse(priceInput);


            var product = new Product
            {
                Name = productName,
                UserId = userId,
                Description = description,
                Price = priceInput,
            };

            await this.productRepository.AddAsync(product);
            await this.productRepository.SaveChangesAsync();
            return product.Id;
        }

        public IEnumerable<T> GetAll<T>()
        {
            var query = this.productRepository.All()
                .OrderByDescending(x => x.CreatedOn);

            return query.To<T>().ToList();
        }

        public T GetById<T>(int id)
        {
            var product = this.productRepository.All().Where(x => x.Id == id)
                .To<T>().FirstOrDefault();
            return product;
        }
    }
}
