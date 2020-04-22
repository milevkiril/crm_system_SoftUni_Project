namespace CRMSystem.Web.ViewModels.Orders
{
    using CRMSystem.Data.Models;
    using CRMSystem.Services.Mapping;

    public class CreateOrderViewModel : IMapFrom<Order>
    {
        public int DealId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }

        public decimal Price { get; set; }
    }
}
