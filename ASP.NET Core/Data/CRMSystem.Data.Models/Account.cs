namespace CRMSystem.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using CRMSystem.Data.Common.Models;

    public class Account : BaseDeletableModel<int>
    {
        [Required]
        public string AccountName { get; set; }

        public Information Details { get; set; }

        [Required]
        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        [Required]
        public AccountType TypeAccount { get; set; }

        public ICollection<Deal> Deals { get; set; } = new HashSet<Deal>();

        public ICollection<Contact> Contacts { get; set; } = new HashSet<Contact>();
    }
}
