namespace CRMSystem.Web.Areas.Administration.Controllers
{
    using CRMSystem.Common;
    using CRMSystem.Data.Models;
    using CRMSystem.Web.Controllers;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
    [Area("Administration")]
    public class AdministrationController : BaseController
    {       
    }
}
