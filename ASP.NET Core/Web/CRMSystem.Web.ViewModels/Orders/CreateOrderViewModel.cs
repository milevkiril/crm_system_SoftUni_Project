﻿namespace CRMSystem.Web.ViewModels.Orders
{
    using AutoMapper;
    using CRMSystem.Data.Models;
    using CRMSystem.Services.Mapping;
    using CRMSystem.Web.ViewModels.Products;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;

    public class CreateOrderViewModel : IMapTo<Order>, IHaveCustomMappings
    {

        [Required]
        public int DealId { get; set; }

        [Required]
        public int ProductId { get; set; }

        public IEnumerable<ProductDropDownViewModel> Products { get; set; }

        public decimal ProductPrice { get; set; }

        [Required]
        public int Quantity { get; set; }

        public decimal Price { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<CreateOrderViewModel, Order>()
                .ForMember(x => x.Price, s => s.MapFrom(x => x.ProductPrice * x.Quantity));
        }
    }
}
