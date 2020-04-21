namespace CRMSystem.Web.Controllers
{
    using CRMSystem.Data;
    using CRMSystem.Data.Models;
    using CRMSystem.Data.Models.Enumerators;
    using CRMSystem.Services.Data;
    using CRMSystem.Web.ViewModels.Deals;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    public class DealsController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IDealsService dealsService;
        private readonly ApplicationDbContext context;

        public DealsController(
            UserManager<ApplicationUser> userManager,
            IDealsService dealsService,
            ApplicationDbContext context)
        {
            this.userManager = userManager;
            this.dealsService = dealsService;
            this.context = context;
        }

        public IActionResult Create()
        {
            return this.View();
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Create(DealCreateViewModel input)
        {
            var user = await this.userManager.GetUserAsync(this.User);
            var userId = await this.userManager.GetUserIdAsync(user);
            input.UserId = userId;

            if (!this.ModelState.IsValid || input.UserId == null)
            {
                return this.View(input);
            }

            Stage stage = (Stage)Enum.ToObject(typeof(AccountType), input.Stage);

            var dealId = await this.dealsService.CreateAsync(input.Name, input.UserId, input.Description, stage, input.AccountId);
            this.TempData["InfoMessage"] = "Deal created!";
            return this.Redirect("/Deals/GetAll");
        }

        public IActionResult ById(int id)
        {
            var dealViewModel = this.dealsService.GetById<DealViewModel>(id);
            if (dealViewModel == null)
            {
                return this.NotFound();
            }

            return this.View(dealViewModel);
        }

        public IActionResult GetAll()
        {
            var viewModel = new AllDealsViewModel
            {
                Deals = this.dealsService.GetAll<DealViewModel>(),
            };
            if (viewModel == null)
            {
                return this.NotFound();
            }

            return this.View(viewModel);
        }

        // GET: Administration/Products/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var deal = await context.Deals.FindAsync(id);
            if (deal == null)
            {
                return NotFound();
            }
            ViewData["UserId"] = new SelectList(context.Users, "Id", "FirstName", deal.UserId);
            return View(deal);
        }

        // POST: Administration/Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Name,UserId,IsDeleted,DeletedOn,Id,CreatedOn,ModifiedOn, Stage")] Deal deal)
        {
            if (id != deal.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    context.Update(deal);
                    await context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DealExists(deal.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }
            ViewData["UserId"] = new SelectList(context.Users, "Id", "FirstName", deal.UserId);


            return this.RedirectToAction("GetAll");
        }

        // GET: Administration/Products/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var deal = await context.Deals
                .Include(d => d.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (deal == null)
            {
                return NotFound();
            }

            return View(deal);
        }

        // GET: Administration/Products/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var deal = await context.Deals
                .Include(d => d.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (deal == null)
            {
                return NotFound();
            }

            return View(deal);
        }

        // POST: Administration/Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var deal = await context.Deals.FindAsync(id);
            context.Deals.Remove(deal);
            await context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DealExists(int id)
        {
            return context.Deals.Any(e => e.Id == id);
        }
    }
}
