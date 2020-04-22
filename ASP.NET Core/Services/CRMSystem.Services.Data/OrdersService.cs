namespace CRMSystem.Services.Data
{
    using CRMSystem.Data.Common.Repositories;
    using CRMSystem.Data.Models;
    using System.Threading.Tasks;

    public class OrdersService : IOrdersService
    {
        private readonly IDeletableEntityRepository<Order> orderRepository;

        public OrdersService(IDeletableEntityRepository<Order> orderRepository)
        {
            this.orderRepository = orderRepository;
        }

        public async Task Create(int dealId, int productId, int quantity)
        {
            var order = new Order
            {
                DealId = dealId,
                ProductId = productId,
                Quantity = quantity,
            };
            await this.orderRepository.AddAsync(order);
            await this.orderRepository.SaveChangesAsync();
        }
    }
}
