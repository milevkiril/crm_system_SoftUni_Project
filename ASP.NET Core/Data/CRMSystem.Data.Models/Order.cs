namespace CRMSystem.Data.Models
{
    using CRMSystem.Data.Common.Models;
    using System.ComponentModel.DataAnnotations;

    public class Order : BaseDeletableModel<int>
    {

        [Required]
        public int DealId { get; set; }

        public Deal Deal { get; set; }

        [Required]
        public int ProductId { get; set; }

        public Product Product { get; set; }

        [Required]
        public int Quantity { get; set; }

        public decimal Price { get; set; }

    }
}
