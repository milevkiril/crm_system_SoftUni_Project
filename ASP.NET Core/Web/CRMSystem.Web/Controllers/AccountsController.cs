using AutoMapper;
using CRMSystem.Data.Models;
using CRMSystem.Services.Data;
using CRMSystem.Web.ViewModels.Accounts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
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
        private readonly IMapper mapper;

        public AccountsController(
            IAccountsService accountsService,
            UserManager<ApplicationUser> userManager)
        {
            this.accountsService = accountsService;
            this.userManager = userManager;
        }

<<<<<<< HEAD
        
=======
>>>>>>> 5c1d09cda30939a408f8dac636b462151659c0ea
        public IActionResult ById(int id)
        {
            var postViewModel = this.accountsService.GetById<AccountViewModel>(id);
            if (postViewModel == null)
            {
                return this.NotFound();
            }

            return this.View(postViewModel);
        }

<<<<<<< HEAD
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

=======
>>>>>>> 5c1d09cda30939a408f8dac636b462151659c0ea
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
    }
}
