namespace GameCollectorsHub.Web.Areas.Administration.Controllers
{
    using GameCollectorsHub.Services.Data;
    using GameCollectorsHub.Web.ViewModels.Administration.Dashboard;

    using Microsoft.AspNetCore.Mvc;

    public class DashboardController : AdministrationController
    {

        public DashboardController()
        {
        }

        public IActionResult Index()
        {
            return this.View();
        }
    }
}
