namespace CRMSystem.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using CRMSystem.Data.Common.Models;
    using CRMSystem.Data.Models.Enumerators;

    public class Deal : BaseDeletableModel<int>
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        public decimal TotalAmount { get; set; }

        public Stage Stage { get; set; }

        [Required]
        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        [Required]
        public int AccountId { get; set; }

        public virtual Account Account { get; set; }

        public virtual ICollection<DealsProductsQuantity> Products { get; set; } = new HashSet<DealsProductsQuantity>();

        public decimal Amount { get; set; } // The total amount of the deal

        public virtual ICollection<Contact> Contacts { get; set; } = new HashSet<Contact>();

        public virtual ICollection<Order> Orders { get; set; } = new HashSet<Order>();
    }
}
