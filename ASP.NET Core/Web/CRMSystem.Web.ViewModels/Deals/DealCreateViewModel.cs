namespace CRMSystem.Web.ViewModels.Deals
{
    using CRMSystem.Data.Models;
    using CRMSystem.Data.Models.Enumerators;
    using CRMSystem.Services.Mapping;
    using System.ComponentModel.DataAnnotations;

    public class DealCreateViewModel : IMapTo<Deal>
    {
        [Required]
        public string Name { get; set; }

        public string UserId { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public Stage Stage { get; set; }

        public int AccountId { get; set; }

        public string AccountName { get; set; }
    }
}
