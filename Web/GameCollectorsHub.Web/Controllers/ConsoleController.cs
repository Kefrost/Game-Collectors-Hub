namespace GameCollectorsHub.Web.Controllers
{
    using GameCollectorsHub.Services.Data;
    using GameCollectorsHub.Web.ViewModels.Platform;
    using Microsoft.AspNetCore.Mvc;

    public class ConsoleController : Controller
    {
        private readonly IPlatformService platform;

        public ConsoleController(IPlatformService platform)
        {
            this.platform = platform;
        }

        public IActionResult Platforms()
        {
            var platforms = this.platform.GetPlatforms();

            var viewModel = new PlatformsViewModel { Platforms = platforms };

            return this.View(viewModel);
        }
    }
}
