namespace CRMSystem.Web.ViewModels.Accounts
{
    using CRMSystem.Data.Models;
    using CRMSystem.Services.Mapping;
    using System;

    public class AccountViewModel : IMapFrom<Account>
    {
        //public DateTime CreatedOn { get; set; }

        public string AccountName { get; set; }

        //public Information Details { get; set; }
       
        //public int UserId { get; set; }

        //public virtual ApplicationUser User { get; set; }

        //public AccountType TypeAccount { get; set; }

        //public ICollection<Deal> Deals { get; set; } = new HashSet<Deal>();

        //public ICollection<Contact> Contacts { get; set; } = new HashSet<Contact>();
    }
}