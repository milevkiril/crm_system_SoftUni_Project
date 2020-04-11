namespace CRMSystem.Web.Areas.Administration.Controllers
{
    using CRMSystem.Services.Data;
    using CRMSystem.Web.ViewModels.Administration.Dashboard;

    using Microsoft.AspNetCore.Mvc;

    public class DashboardController : RolesController
    {
        //private static readonly RolesService rolesService;
        private readonly ISettingsService settingsService;

        public DashboardController(ISettingsService settingsService)
            //: base(rolesService)
        {
            this.settingsService = settingsService;
        }

        public IActionResult Index()
        {
            var viewModel = new IndexViewModel { SettingsCount = this.settingsService.GetCount(), };
            return this.View(viewModel);
        }
    }
}
