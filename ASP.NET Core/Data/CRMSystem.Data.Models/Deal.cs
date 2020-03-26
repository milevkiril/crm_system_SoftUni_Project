namespace CRMSystem.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using CRMSystem.Data.Common.Models;

    public class Deal : BaseDeletableModel<int>
    {
        public int DealId { get; set; }

        public string Name { get; set; }

        [Required]
        public int UserId { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }

        public virtual ICollection<DealsProductsQuantity> Products { get; set; } = new HashSet<DealsProductsQuantity>();

        public decimal Amount { get; set; } // The total amount of the deal

        public virtual ICollection<Contact> Contacts { get; set; } = new HashSet<Contact>();
    }
}
