using CRMSystem.Data.Models;
using CRMSystem.Services.Mapping;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CRMSystem.Web.ViewModels.Accounts
{
    public class AccountCreateViewModel : IMapTo<Account>
    {
        [Required]
        public string AccountName { get; set; }

        public string UserId { get; set; }

        [Required]
        public AccountType TypeAccount { get; set; }
    }
}
