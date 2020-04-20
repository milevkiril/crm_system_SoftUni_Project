using AutoMapper;
using CRMSystem.Data.Models;
using CRMSystem.Data.Models.Enumerators;
using CRMSystem.Services.Mapping;
using System;

namespace CRMSystem.Web.ViewModels.Deals
{
    public class DealViewModel : IMapFrom<Deal>
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public Stage Stage { get; set; }

        public string DealOwner { get; set; }

        public string AccountAccountName { get; set; }

        public DateTime CreatedOn { get; set; }

        public string Url => $"/Deals/GetAll";
    }
}
