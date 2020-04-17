namespace CRMSystem.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using CRMSystem.Data.Common.Models;

    public class Product : BaseDeletableModel<int>
    {
        [Required]
        public int ProductId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [Range(1, 100)]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Price { get; set; }

        [Required]
        public string Description { get; set; }

        public string CreatedBy { get; set; }

        [Required]
        public string UserId { get; set; }

        public ApplicationUser ApplicationUser { get; set; }

        public virtual ICollection<DealsProductsQuantity> Deals { get; set; } = new HashSet<DealsProductsQuantity>();
    }
}
