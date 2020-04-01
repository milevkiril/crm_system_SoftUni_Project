namespace CRMSystem.Web.Controllers
{
    using CRMSystem.Services;
    using CRMSystem.Web.ViewModels;
    using CRMSystem.Web.ViewModels.Users;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using System.Threading.Tasks;

    public class UsersController : Controller
    {
        private readonly IUsersService usersService;
        private readonly ILogger logger;

        public UsersController(IUsersService usersService, ILogger logger)
        {
            this.usersService = usersService;
            this.logger = logger;
        }

        public IActionResult ById(string username, string password)
        {
            var getUserViewModel = this.usersService.GetById<UserViewModel>(username, password);
            if (getUserViewModel == null)
            {
                return this.NotFound();
            }

            return this.View(getUserViewModel);
        }

        //[HttpPost]
        //public HttpResponse Register(RegisterInputModel input)
        //{
        //    //if (input.Password != input.ConfirmPassword)
        //    //{
        //    //    return this.Error("Passwords should be the same!");
        //    //}

        //    //if (input.Username?.Length < 5 || input.Username?.Length > 20)
        //    //{
        //    //    return this.Error("Username should be between 5 and 20 characters .");
        //    //}

        //    //if (input.Password?.Length < 6 || input.Password?.Length > 20)
        //    //{
        //    //    return this.Error("Password should be between 6 and 20 characters.");
        //    //}

        //    //if (!IsValid(input.Email))
        //    //{
        //    //    return this.Error("Invalid email!");
        //    //}

        //    //if (this.usersService.IsUsernameUsed(input.Username))
        //    //{
        //    //    return this.Error("Username already used!");
        //    //}

        //    //if (this.usersService.IsEmailUsed(input.Email))
        //    //{
        //    //    return this.Error("Email already used!");
        //    //}

        //   // this.usersService.CreateUser(input.Username, input.Email, input.Password);
        //   //// this.logger.Log("New user: " + input.Username);
        //   // return this.Redirect();
        //}
    }
}
