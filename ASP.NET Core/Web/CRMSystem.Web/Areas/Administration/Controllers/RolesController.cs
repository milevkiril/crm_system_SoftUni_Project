namespace CRMSystem.Web.Areas.Administration.Controllers
{
    using CRMSystem.Common;
    using CRMSystem.Data.Models;
    using CRMSystem.Services.Data;
    using CRMSystem.Web.Controllers;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;

    [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
    [Area("Administration")]
    public class RolesController : BaseController
    {
        //private readonly RolesService rolesService;

        //public RolesController(RolesService rolesService)
        //{
        //    this.rolesService = rolesService;
        //}

        public IActionResult CreateRole()
        {
            return this.View();
        }

        //[HttpPost]
        //[Authorize]
        //public async Task<IActionResult> CreateRole(string name)
        //{
        //    var role = await this.rolesService.CreateAsync(name);
        //    this.TempData["InfoMessage"] = "Role created!";
        //    return this.RedirectToAction("");
        //}
    }
}
