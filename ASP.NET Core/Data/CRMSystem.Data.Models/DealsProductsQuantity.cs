namespace CRMSystem.Data.Models
{
    public class DealsProductsQuantity
    {
        public int DealId { get; set; }

        public Deal Deal { get; set; }

        public int ProductId { get; set; }

        public Product Product { get; set; }

        public int Quantity { get; set; }
    }
}
