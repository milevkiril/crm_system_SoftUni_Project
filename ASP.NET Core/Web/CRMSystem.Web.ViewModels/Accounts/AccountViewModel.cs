namespace CRMSystem.Web.ViewModels.Accounts
{
    using CRMSystem.Data.Models;
    using CRMSystem.Services.Mapping;
    using System;
    using System.Collections.Generic;

    public class AccountViewModel : IMapFrom<Account>
    {
        public int Id { get; set; }

        public DateTime CreatedOn { get; set; }

        public string AccountName { get; set; }

        public string AccountOwner { get; set; }

<<<<<<< HEAD
        public string Url => $"/Accounts/{this.Id}";
=======
        public string Url => $"/f/{this.AccountName.Replace(' ', '-')}";
>>>>>>> 5c1d09cda30939a408f8dac636b462151659c0ea

        //public Information Details { get; set; }

        //public int UserId { get; set; }

        //public virtual ApplicationUser User { get; set; }

        //public AccountType TypeAccount { get; set; }

        public ICollection<Deal> Deals { get; set; } = new HashSet<Deal>();

        //public ICollection<Contact> Contacts { get; set; } = new HashSet<Contact>();
    }
}