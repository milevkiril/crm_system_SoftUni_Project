namespace CRMSystem.Web.Controllers
{
    using CRMSystem.Data.Models;
    using CRMSystem.Services.Data;
    using CRMSystem.Web.Areas.Administration.ViewModels.Products;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    
    public class AllProductsController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IProductService productService;

        public AllProductsController(
            UserManager<ApplicationUser> userManager,

            IProductService productService)
        {
            this.userManager = userManager;
            this.productService = productService;
        }

        public IActionResult GetAll()
        {
            var viewModel = new AllProductsViewModel
            {
                Products = this.productService.GetAll<ProductViewModel>(),
            };
            if (viewModel == null)
            {
                return this.NotFound();
            }

            return this.View(viewModel);
        }
    }
}
