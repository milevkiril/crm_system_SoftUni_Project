using CRMSystem.Common;
using CRMSystem.Data;
using CRMSystem.Data.Models;
using CRMSystem.Services.Data;
using CRMSystem.Web.ViewModels.Orders;
using CRMSystem.Web.ViewModels.Products;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CRMSystem.Web.Controllers
{
    [Authorize]
    public class OrdersController : Controller
    {
        private readonly IOrdersService ordersService;
        private readonly IProductService productService;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly ApplicationDbContext _context;

        public OrdersController(
            IOrdersService ordersService,
            IProductService productService,
            ApplicationDbContext _context,
            UserManager<ApplicationUser> userManager)
        {
            this.ordersService = ordersService;
            this.productService = productService;
            this.userManager = userManager;
            _context = _context;
        }

       
        public IActionResult Create(int id)
        {
            var products = this.productService.GetAll<ProductDropDownViewModel>();
            var model = new CreateOrderViewModel() { Products = products };
            model.DealId = id;
            //ViewData["ProductId"] = _context.Products.Select(x => new SelectListItem(x.Name, x.Id.ToString()));
            return this.View(model);
        }
       
        [HttpPost]
        public async Task<IActionResult> Create(CreateOrderViewModel input)
        {
            var user = await this.userManager.GetUserAsync(this.User);
            var userId = await this.userManager.GetUserIdAsync(user);

            if (!this.ModelState.IsValid || userId == null)
            {
                return this.View(input);
            }
            var productPrice = await this.productService.GetProductPriceByIdAsync(input.ProductId);
            input.ProductPrice = productPrice;
            await this.ordersService.CreateAsync(input);

            this.TempData["InfoMessage"] = "Order created!";
            return this.RedirectToAction("ById", "Deals", new { id = input.DealId });
        }
    }
}
