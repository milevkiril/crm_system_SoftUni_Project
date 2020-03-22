﻿namespace CRMSystem.Data.Models
{
    using System.Collections.Generic;

    using CRMSystem.Data.Common.Models;

    public class Product : BaseDeletableModel<int>
    {
        public int ProductId { get; set; }

        public string Name { get; set; }

        public decimal MyProperty { get; set; }

        public string Description { get; set; }

        public virtual ICollection<DealsProductsQuantity> Deals { get; set; } = new HashSet<DealsProductsQuantity>();
    }
}