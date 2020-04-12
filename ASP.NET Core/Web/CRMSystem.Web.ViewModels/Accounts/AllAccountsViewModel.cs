using System.Collections.Generic;

namespace CRMSystem.Web.ViewModels.Accounts
{
    public class AllAccountsViewModel
    {
        public IEnumerable<AccountViewModel> Accounts { get; set; }
    }
}
