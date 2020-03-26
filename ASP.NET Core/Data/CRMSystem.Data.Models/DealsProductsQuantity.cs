using System.ComponentModel.DataAnnotations;

namespace CRMSystem.Data.Models
{
    public class DealsProductsQuantity
    {
        [Required]
        public int DealId { get; set; }

        public Deal Deal { get; set; }

        [Required]
        public int ProductId { get; set; }

        public Product Product { get; set; }

        [Required]
        public int Quantity { get; set; }
    }
}
