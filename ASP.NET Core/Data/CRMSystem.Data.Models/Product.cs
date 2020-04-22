namespace CRMSystem.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using CRMSystem.Data.Common.Models;

    public class Product : BaseDeletableModel<int>
    {

        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [RegularExpression(@"\d+(,\d{2})?")]
        public string Price { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        public virtual ICollection<DealsProductsQuantity> Deals { get; set; } = new HashSet<DealsProductsQuantity>();

        public virtual ICollection<Order> Orders { get; set; } = new HashSet<Order>();
    }
}
