using CRMSystem.Data.Common.Models;
using System.ComponentModel.DataAnnotations;

namespace CRMSystem.Data.Models
{
    public class Order : BaseDeletableModel<int>
    {
        public int Id { get; set; }

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
