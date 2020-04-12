namespace CRMSystem.Web.ViewModels.Accounts
{
    using CRMSystem.Data.Models;
    using CRMSystem.Services.Mapping;

    public class TypeAccountDropDownViewModel : IMapFrom<AccountType>
    {
        public AccountType TypeAccount { get; set; }
    }
}
