namespace CRMSystem.Web.Controllers
{
    using CRMSystem.Data.Models;
    using CRMSystem.Data.Models.Enumerators;
    using CRMSystem.Services.Data;
    using CRMSystem.Web.ViewModels.Deals;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Threading.Tasks;

    public class DealsController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IDealsService dealsService;

        public DealsController(
            UserManager<ApplicationUser> userManager,
            IDealsService dealsService)
        {
            this.userManager = userManager;
            this.dealsService = dealsService;
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

            var dealId = await this.dealsService.CreateAsync(input.Name, input.UserId, input.Description, stage, input.AccountId, input.AccountName);
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
            if(viewModel == null)
            {
                return this.NotFound();
            }

            return this.View(viewModel);
        }
    }
}
