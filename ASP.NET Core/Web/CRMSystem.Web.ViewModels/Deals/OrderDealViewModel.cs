namespace CRMSystem.Web.ViewModels.Deals
{
    using CRMSystem.Data.Models;
    using CRMSystem.Services.Mapping;

    public class OrderDealViewModel : IMapFrom<Order>
    {
        public int Id { get; set; }
        public int DealId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }

        public decimal Price { get; set; }

        public string ProductName { get; set; }
    }
}
