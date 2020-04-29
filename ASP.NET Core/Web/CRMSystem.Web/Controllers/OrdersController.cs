using CRMSystem.Common;
using CRMSystem.Data;
using CRMSystem.Data.Common.Repositories;
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
        private readonly IDeletableEntityRepository<Deal> dealRepository;
        private readonly IDeletableEntityRepository<Order> orderRepository;
        private readonly IDeletableEntityRepository<Product> productRepository;
        private readonly ApplicationDbContext _context;

        public OrdersController(
            IOrdersService ordersService,
            IProductService productService,
            ApplicationDbContext _context,
            UserManager<ApplicationUser> userManager,
            IDeletableEntityRepository<Deal> dealRepository,
            IDeletableEntityRepository<Order> orderRepository,
            IDeletableEntityRepository<Product> productRepository)
        {
            this.ordersService = ordersService;
            this.productService = productService;
            this.userManager = userManager;
            this.dealRepository = dealRepository;
            this.orderRepository = orderRepository;
            this.productRepository = productRepository;
            _context = _context;
        }

        public IActionResult ById(int id)
        {

            var orderViewModel = this.ordersService.GetById<OrderViewModel>(id);
            if (orderViewModel == null)
            {
                this.TempData["InfoMessage"] = "Order not found!";
                return this.Redirect("/Deals/GetAll");
            }

            return this.View(orderViewModel);
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

            var deal = this.dealRepository.All()
                .Where(x => x.UserId == userId)
                .FirstOrDefault();
            //var order = this.orderRepository.All()
            //    .Where(x => x.Id == input.Id)
            //    .FirstOrDefault();


            this.TempData["InfoMessage"] = "Order created!";
            return this.RedirectToAction("ById", "Deals", new { id = input.DealId });
        }


        public async Task<IActionResult> Edit(int id)
        {
            var order = this.orderRepository
                .All()
                .FirstOrDefault(o => o.Id == id);

            var products = this.productService.GetAll<ProductDropDownViewModel>();
            var model = new EditOrderViewModel()
            {
                Price = order.Price,
                DealId = order.DealId,
                ProductId = order.ProductId,
                Quantity = order.Quantity,
                Products = products,
                ProductPrice = await this.productService.GetProductPriceByIdAsync(order.ProductId),
            };
            model.DealId = order.DealId;
            //ViewData["ProductId"] = _context.Products.Select(x => new SelectListItem(x.Name, x.Id.ToString()));
            return this.View(model);
        }

        // POST:
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Edit(EditOrderViewModel input)
        {
            var order = this.orderRepository
                .All()
                .FirstOrDefault(o => o.Id == input.Id);
            //var product = this.productRepository
            //    .All()
            //    .FirstOrDefault(o => o.Id == input.ProductId);

            var price = await this.productService.GetProductPriceByIdAsync(order.ProductId);

            order.ProductId = input.ProductId;
            order.Quantity = input.Quantity;
            order.Price = price * input.Quantity;


            if (input.DealId == null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    
                    await this.orderRepository.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    return NotFound();
                }
            }


            return this.RedirectToAction("ById", "Deals", new { id = input.DealId });
        }

        private bool OrderExists(int id)
        {
            return _context.Orders.Any(e => e.Id == id);
        }
    }
}
