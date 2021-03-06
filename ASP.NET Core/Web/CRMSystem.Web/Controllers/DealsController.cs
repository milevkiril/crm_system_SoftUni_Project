﻿namespace CRMSystem.Web.Controllers
{
    using CRMSystem.Common;
    using CRMSystem.Data;
    using CRMSystem.Data.Common.Repositories;
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
    using System.Security.Claims;
    using System.Threading.Tasks;


    [Authorize]
    public class DealsController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IDealsService dealsService;
        private readonly ApplicationDbContext context;
        private readonly IDeletableEntityRepository<Deal> dealRepository;

        public DealsController(
            UserManager<ApplicationUser> userManager,
            IDealsService dealsService,
            ApplicationDbContext context,
            IDeletableEntityRepository<Deal> dealRepository)
        {
            this.userManager = userManager;
            this.dealsService = dealsService;
            this.context = context;
            this.dealRepository = dealRepository;
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
                this.TempData["InfoMessage"] = "Deal not found!";
                return this.Redirect("/Deals/GetAll");
            }

            return this.View(dealViewModel);
        }

        public IActionResult GetAll(string searchBy, string search)
        {
            var viewModel = new AllDealsViewModel
            {
                Deals = this.dealsService.GetAll<DealViewModel>(searchBy, search),
            };
            if (viewModel == null)
            {
                return this.NotFound();
            }

            return this.View(viewModel);
        }

        // GET: 
        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            var deal = dealRepository.All().Where(d => d.Id == id).FirstOrDefault();//await context.Deals
                                                                                    //.Include(d => d.User)
                                                                                    //FirstOrDefaultAsync(m => m.Id == id);

            if (id == null || deal == null)
            {
                this.TempData["InfoMessage"] = "Deal not found!";
                return this.Redirect("/Deals/GetAll");
            }

            if (!this.User.IsInRole(GlobalConstants.AdministratorRoleName) || this.User.FindFirstValue(ClaimTypes.NameIdentifier) != deal.UserId)
            {
                return this.RedirectToAction("GetAll");
            }

            if (deal == null)
            {
                return NotFound();
            }
            ViewData["UserId"] = new SelectList(context.Users, "Id", "FirstName", deal.UserId);
            ViewData["AccountId"] = context.Accounts.Select(x => new SelectListItem(x.AccountName, x.Id.ToString()));
            //ViewData["AccountId"] = new SelectList(context.Accounts, "Id", "AccountName", deal.AccountId); Питай Ники и Стоян защо не работи
            return View(deal);
        }

        // POST:
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Edit(int id, [Bind("Name,UserId,AccountId,IsDeleted,DeletedOn,CreatedOn, Id,ModifiedOn,Stage")] Deal deal)
        {
            if (id != deal.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    dealRepository.Update(deal);//context.Update(deal);
                    await dealRepository.SaveChangesAsync();
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
            ViewData["AccountId"] = new SelectList(context.Accounts, "Id", "Id", deal.AccountId);


            return this.RedirectToAction("GetAll");
        }

        // GET:
        public async Task<IActionResult> Details(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }

            var deal = dealRepository.All().Where(d => d.Id == id).FirstOrDefault();//await context.Deals
                                                                                    //.Include(d => d.User)
                                                                                    //FirstOrDefaultAsync(m => m.Id == id);

            if (deal == null)
            {
                this.TempData["InfoMessage"] = "Deal not found!";
                return this.Redirect("/Deals/GetAll");
            }

            if (this.User.FindFirstValue(ClaimTypes.NameIdentifier) != deal.UserId)
            {
                return this.RedirectToAction("GetAll");
            }

            if (deal == null)
            {
                return NotFound();
            }

            return View(deal);
        }

        // GET:
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var deal = dealRepository.All().Where(d => d.Id == id).FirstOrDefault();//await context.Deals
                                                                                    //.Include(d => d.User)
                                                                                    //FirstOrDefaultAsync(m => m.Id == id);

            if (deal == null)
            {
                this.TempData["InfoMessage"] = "Deal not found!";
                return this.Redirect("/Deals/GetAll");
            }

            if (!this.User.IsInRole(GlobalConstants.AdministratorRoleName) || this.User.FindFirstValue(ClaimTypes.NameIdentifier) != deal.UserId)
            {
                return this.RedirectToAction("GetAll");
            }

            if (deal == null)
            {
                return NotFound();
            }

            return View(deal);
        }

        // POST:
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var deal = dealRepository.All().Where(d => d.Id == id).FirstOrDefault();//context.Deals.FindAsync(id);
            context.Deals.Remove(deal);
            await context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DealExists(int id)
        {
            return dealRepository.All().Any(e => e.Id == id);//Where(e => e.Id == id);
        }
    }
}
