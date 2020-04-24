using CRMSystem.Common;
using CRMSystem.Data;
using CRMSystem.Data.Models;
using CRMSystem.Services.Data;
using CRMSystem.Web.ViewModels.Orders;
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

        // GET: 
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            //var deal = await _context.Deals.FindAsync(id);

            //if (id == null)
            //{
            //    return NotFound();
            //}

            //if (!this.User.IsInRole(GlobalConstants.AdministratorRoleName) || this.User.FindFirstValue(ClaimTypes.NameIdentifier) != deal.UserId)
            //{
            //    return this.RedirectToAction("GetAll");
            //}

            //if (deal == null)
            //{
            //    return NotFound();
            //}
            //ViewData["DealId"] = new SelectList(_context.Deals, "Id", "Name", deal.Id);
            //ViewData["ProductId"] = _context.Products.Select(x => new SelectListItem(x.Name, x.Id.ToString()));
            ////ViewData["AccountId"] = new SelectList(context.Accounts, "Id", "AccountName", deal.AccountId); Питай Ники и Стоян защо не работи
            return View();
        }

        // POST:
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Edit(int id, [Bind("DealId,ProductId,Quantity,IsDeleted,DeletedOn,CreatedOn, Id,ModifiedOn")] Order order)
        {
            if (id != order.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(order);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DealExists(order.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }
            ViewData["DealId"] = new SelectList(_context.Deals, "Id", "Name", order.DealId);
            ViewData["ProductId"] = new SelectList(_context.Products, "Id", "Name", order.ProductId);


            return this.RedirectToAction("GetAll");
        }

        private bool DealExists(int id)
        {
            return _context.Orders.Any(e => e.Id == id);
        }
        //public IActionResult Create()
        //{
        //    ViewData["DealId"] = new SelectList(_context.Users, "Id", "Id");
        //    ViewData["ProductdBy"] = new SelectList(_context.Users, "Name", "Name");
        //    return this.View();
        //}

        //[Authorize]
        //[HttpPost]
        //public async Task<IActionResult> Create(CreateOrderViewModel input)
        //{
        //    var user = await this.userManager.GetUserAsync(this.User);
        //    var userId = await this.userManager.GetUserIdAsync(user);
        //    var userIdCheck = userId;

        //    if (!this.ModelState.IsValid || userIdCheck == null)
        //    {
        //        return this.View(input);
        //    }

        //    var dealId = await this.ordersService.CreateAsync(input.DealId, input.ProductId, input.Quantity);
        //    this.TempData["InfoMessage"] = "Order created!";
        //    return this.Redirect("/Deals/GetAll");
        //}
    }
}
