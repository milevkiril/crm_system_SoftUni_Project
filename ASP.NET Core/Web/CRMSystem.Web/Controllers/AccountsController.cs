using AutoMapper;
using CRMSystem.Data.Models;
using CRMSystem.Services.Data;
using CRMSystem.Web.ViewModels.Accounts;
using CRMSystem.Web.ViewModels.NewFolder;
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
            return this.Redirect("/Users/GetAll");
            //return this.RedirectToAction(nameof(this.ById), new { id = postId });
        }
        //public IActionResult GetAll()
        //{
        //    var viewModel = new AllAccountsViewModel
        //    {
        //        //Users = this.usersService.GetAll<AccountViewModel>(),
        //    };

        //    return this.View(viewModel);
        //}
    }
}
