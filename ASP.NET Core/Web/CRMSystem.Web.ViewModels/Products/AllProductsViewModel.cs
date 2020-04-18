using System.Collections.Generic;

namespace CRMSystem.Web.Areas.Administration.ViewModels.Products
{
    public class AllProductsViewModel
    {
        public IEnumerable<ProductViewModel> Products { get; set; }
    }
}
