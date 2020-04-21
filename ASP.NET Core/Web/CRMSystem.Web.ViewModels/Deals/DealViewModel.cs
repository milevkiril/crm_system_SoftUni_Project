using AutoMapper;
using CRMSystem.Data.Models;
using CRMSystem.Data.Models.Enumerators;
using CRMSystem.Services.Mapping;
using System;

namespace CRMSystem.Web.ViewModels.Deals
{
    public class DealViewModel : IMapFrom<Deal>
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Description { get; set; }

        public string UserId { get; set; }

        public Stage Stage { get; set; }

        public string UserUserName { get; set; }

        public string AccountAccountName { get; set; }

        public DateTime CreatedOn { get; set; }

        public string Url => $"/Deals/{this.Id}";
    }
}
