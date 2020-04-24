using CRMSystem.Data;
using CRMSystem.Data.Models;
using CRMSystem.Services.Data;
using CRMSystem.Web.ViewModels.Orders;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace CRMSystem.Web.Controllers
{
    public class OrdersController : Controller
    {
        private readonly IOrdersService ordersService;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly ApplicationDbContext _context;

        public OrdersController(
            IOrdersService ordersService,
            ApplicationDbContext _context,
            UserManager<ApplicationUser> userManager)
        {
            this.ordersService = ordersService;
            this.userManager = userManager;
            _context = _context;
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Create(CreateOrderViewModel input)
        {
            var user = await this.userManager.GetUserAsync(this.User);
            var userId = await this.userManager.GetUserIdAsync(user);
            var userIdCheck = userId;

            if (!this.ModelState.IsValid || userIdCheck == null)
            {
                return this.View(input);
            }
            
            var dealId = await this.ordersService.CreateAsync(input.DealId, input.ProductId, input.Quantity);
            this.TempData["InfoMessage"] = "Order created!";
            return this.Redirect("/Deals/GetAll");
        }
    }
}
