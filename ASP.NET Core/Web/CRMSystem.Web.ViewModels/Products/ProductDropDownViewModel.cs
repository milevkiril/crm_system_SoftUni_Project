﻿using CRMSystem.Data.Models;
using CRMSystem.Services.Mapping;

namespace CRMSystem.Web.ViewModels.Products
{
    public class ProductDropDownViewModel : IMapFrom<Product>
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
