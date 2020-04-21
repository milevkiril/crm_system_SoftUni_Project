namespace CRMSystem.Web.Areas.Administration.ViewModels.Products
{
    using CRMSystem.Data.Models;
    using CRMSystem.Services.Mapping;
    using System;

    public class ProductViewModel : IMapFrom<Product>
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public string UserUserName { get; set; }

        public string Price { get; set; }

        public DateTime CreatedOn { get; set; }

        public string Url => $"/Products/GetAll";
    }
}
