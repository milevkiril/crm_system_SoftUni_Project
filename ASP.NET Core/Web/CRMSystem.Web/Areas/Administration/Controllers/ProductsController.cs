namespace CRMSystem.Web.Controllers
{
    using CRMSystem.Common;
    using CRMSystem.Data.Models;
    using CRMSystem.Services.Data;
    using CRMSystem.Web.Areas.Administration.ViewModels;
    using CRMSystem.Web.Areas.Administration.ViewModels.Products;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Threading.Tasks;

    [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
    [Area("Administration")]
    public class ProductsController : BaseController
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IProductService productService;

        public ProductsController(
            UserManager<ApplicationUser> userManager,
            IProductService productService)
        {
            this.userManager = userManager;
            this.productService = productService;
        }

        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateProductViewModel input)
        {
            var user = await this.userManager.GetUserAsync(this.User);
            var userId = await this.userManager.GetUserIdAsync(user);
            input.UserId = userId;

            if (!this.ModelState.IsValid || input.UserId == null)
            {
                return this.View(input);
            }

            var priceInput = Convert.ToDecimal(input.Price);
            
            var dealId = await this.productService.CreateAsync(input.Name, input.Description, priceInput.ToString(), input.UserId);
            this.TempData["InfoMessage"] = "Product created!";
            return this.Redirect("/Home/");
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
