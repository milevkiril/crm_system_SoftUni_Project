using CRMSystem.Data.Models;
using CRMSystem.Services.Mapping;

namespace CRMSystem.Web.ViewModels.Home
{
    public class IndexAccountViewModel : IMapFrom<Account>
    {
        public string AccountName { get; set; }

        public string AccountOwner { get; set; }

        public string Url => $"/f/{this.AccountOwner.Replace(' ', '-')}";
    }
}
