using CRMSystem.Data.Models;
using CRMSystem.Services.Mapping;

namespace CRMSystem.Web.ViewModels.Orders
{
    public class OrderViewModel : IMapFrom<Order>
    {
        public int Id { get; set; }

        public int DealId { get; set; }

        public Deal Deal { get; set; }

        public int ProductId { get; set; }

        public Product Product { get; set; }

        public int Quantity { get; set; }

        public decimal Price { get; set; }

        public string Url => $"/Orders/{this.Id}";
    }
}
