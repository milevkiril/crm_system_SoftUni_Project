namespace CRMSystem.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using CRMSystem.Data.Common.Models;

    public class Product : BaseDeletableModel<int>
    {

        [Required]
        public string Name { get; set; }

        [Required]
        [RegularExpression(@"\d+(,\d{2})?")]
        public string Price { get; set; }

        [Required]
        public string Description { get; set; }

        public string CreatedBy { get; set; }

        [Required]
        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        public virtual ICollection<DealsProductsQuantity> Deals { get; set; } = new HashSet<DealsProductsQuantity>();
    }
}
