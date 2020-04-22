using CRMSystem.Services.Data;
using CRMSystem.Web.ViewModels.Orders;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CRMSystem.Web.Controllers
{
    public class OrdersController : Controller
    {
        private readonly IOrdersService ordersService;

        public OrdersController(
            IOrdersService ordersService)
        {
            this.ordersService = ordersService;
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create(CreateOrderViewModel input)
        {
            await this.ordersService.Create(input.DealId, input.ProductId, input.Quantity);
            return this.RedirectToAction("ById", "Posts", new { id = input.DealId });
        }
    }
}
