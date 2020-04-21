using System.Collections.Generic;

namespace CRMSystem.Web.ViewModels.Products
{
    public class AllProductsViewModel
    {
        public IEnumerable<ProductViewModel> Products { get; set; }
    }
}
