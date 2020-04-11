using CRMSystem.Data.Models;
using CRMSystem.Services.Mapping;
using System;
using System.Collections.Generic;
using System.Text;

namespace CRMSystem.Web.ViewModels.Accounts
{
    public class TypeAccountDropDownViewModel : IMapFrom<AccountType>
    {
        public AccountType TypeAccount { get; set; }
    }
}
