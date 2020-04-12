namespace CRMSystem.Web.Controllers
{
    using CRMSystem.Data.Models;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    public class DealsController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;

        public DealsController(UserManager<ApplicationUser> userManager)
        {
            this.userManager = userManager;
        }

        public IActionResult Create()
        {
            return this.View();
        }

        //[Authorize]
        //[HttpPost]
        //public async Task<IActionResult> Create(AccountCreateViewModel input)
        //{
        //    var user = await this.userManager.GetUserAsync(this.User);
        //    var userId = await this.userManager.GetUserIdAsync(user);
        //    input.UserId = userId;

        //    if (!this.ModelState.IsValid || input.UserId == null)
        //    {
        //        return this.View(input);
        //    }

        //    AccountType accType = (AccountType)Enum.ToObject(typeof(AccountType), input.TypeAccount);

        //    var postId = await this.accountsService.CreateAsync(input.AccountName, input.UserId, accType);
        //    this.TempData["InfoMessage"] = "Account created!";
        //    return this.Redirect("/Deals/GetAll");
        //}
    }
}
