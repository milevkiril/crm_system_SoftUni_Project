using AutoMapper;
using CRMSystem.Data;
using CRMSystem.Data.Common.Repositories;
using CRMSystem.Data.Models;
using CRMSystem.Services.Data;
using CRMSystem.Web.ViewModels.Accounts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRMSystem.Web.Controllers
{
    public class AccountsController : Controller
    {
        private readonly IAccountsService accountsService;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public AccountsController(
            IAccountsService accountsService,
            UserManager<ApplicationUser> userManager,
            ApplicationDbContext context)
        {
            this.accountsService = accountsService;
            this.userManager = userManager;
            this.context = context;
        }

        public IActionResult ById(int id)
        {
            var accountViewModel = this.accountsService.GetById<AccountViewModel>(id);
            if (accountViewModel == null)
            {
                return this.NotFound();
            }

            return this.View(accountViewModel);
        }

        public IActionResult ByName(string name, int page = 1)
        {
            var viewModel =
                this.accountsService.GetByName<AccountViewModel>(name);
            if (viewModel == null)
            {
                return this.NotFound();
            }

            //viewModel.ForumPosts = this.postsService.GetByCategoryId<PostInCategoryViewModel>(viewModel.Id, ItemsPerPage, (page - 1) * ItemsPerPage);

            //var count = this.postsService.GetCountByCategoryId(viewModel.Id);
            //viewModel.PagesCount = (int)Math.Ceiling((double)count / ItemsPerPage);
            //if (viewModel.PagesCount == 0)
            //{
            //    viewModel.PagesCount = 1;
            //}

            //viewModel.CurrentPage = page;

            return this.View(viewModel);
        }

        public IActionResult Create()
        {
            return this.View();
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Create(AccountCreateViewModel input)
        {
            var user = await this.userManager.GetUserAsync(this.User);
            var userId = await this.userManager.GetUserIdAsync(user);
            input.UserId = userId;

            if (!this.ModelState.IsValid || input.UserId == null)
            {
                return this.View(input);
            }

            AccountType accType = (AccountType)Enum.ToObject(typeof(AccountType), input.TypeAccount);

            var postId = await this.accountsService.CreateAsync(input.AccountName, input.UserId, accType);
            this.TempData["InfoMessage"] = "Account created!";
            return this.Redirect("/Accounts/GetAll");
            //return this.RedirectToAction(nameof(this.ById), new { id = postId });
        }
        
        public IActionResult GetAll()
        {
            var viewModel = new AllAccountsViewModel
            {
                Accounts = this.accountsService.GetAll<AccountViewModel>(),
            };

            return this.View(viewModel);
        }

        // GET: Administration/Products/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var account = await context.Accounts.FindAsync(id);
            if (account == null)
            {
                return NotFound();
            }
            ViewData["UserId"] = new SelectList(context.Users, "Id", "FirstName", account.UserId);
            return View(account);
        }

        // POST: Administration/Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AccountName,AccountOwner,UserId,IsDeleted,DeletedOn,Id,CreatedOn,ModifiedOn, TypeAccount")] Account account)
        {
            if (id != account.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    context.Update(account);
                    await context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AccountExists(account.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }
            ViewData["UserId"] = new SelectList(context.Users, "Id", "FirstName", account.UserId);


            return this.RedirectToAction("GetAll");
        }

        // GET: Administration/Products/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var account = await context.Accounts
                .Include(a => a.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (account == null)
            {
                return NotFound();
            }

            return View(account);
        }


        // GET: Administration/Products/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var account = await context.Accounts
                .Include(p => p.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (account == null)
            {
                return NotFound();
            }

            return View(account);
        }

        // POST: Administration/Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var account = await context.Accounts.FindAsync(id);
            context.Accounts.Remove(account);
            await context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AccountExists(int id)
        {
            return context.Accounts.Any(e => e.Id == id);
        }
    }
}
