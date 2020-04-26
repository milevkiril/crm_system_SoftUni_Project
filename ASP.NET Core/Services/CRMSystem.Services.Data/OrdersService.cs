namespace CRMSystem.Services.Data
{
    using CRMSystem.Data.Common.Repositories;
    using CRMSystem.Data.Models;
    using CRMSystem.Services.Mapping;
    using System.Threading.Tasks;

    public class OrdersService : IOrdersService
    {
        private readonly IDeletableEntityRepository<Order> orderRepository;

        public OrdersService(IDeletableEntityRepository<Order> orderRepository)
        {
            this.orderRepository = orderRepository;
        }

        //public async Task<int> CreateAsync(int dealId, int productId, int quantity)
        //{
        //    var order = new Order
        //    {
        //        DealId = dealId,
        //        ProductId = productId,
        //        Quantity = quantity,
        //    };
        //    await this.orderRepository.AddAsync(order);
        //    await this.orderRepository.SaveChangesAsync();

        //    return order.Id;
        //}

        public async Task<int> CreateAsync<T>(T model)
        {
            var order = AutoMapperConfig.MapperInstance.Map<Order>(model);
            await this.orderRepository.AddAsync(order);
            await this.orderRepository.SaveChangesAsync();

            return order.Id;
        }
    }
}
