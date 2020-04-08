namespace GameCollectorsHub.Web.Controllers
{
    using System.Threading.Tasks;

    using GameCollectorsHub.Services.Data;
    using GameCollectorsHub.Web.ViewModels.Console;
    using GameCollectorsHub.Web.ViewModels.Platform;
    using Microsoft.AspNetCore.Mvc;

    public class ConsoleController : Controller
    {
        private readonly IPlatformService platform;
        private readonly IConsoleService console;

        public ConsoleController(IPlatformService platform, IConsoleService console)
        {
            this.platform = platform;
            this.console = console;
        }

        public IActionResult Platforms()
        {
            var platforms = this.platform.GetPlatforms();

            var viewModel = new PlatformsViewModel { Platforms = platforms };

            return this.View(viewModel);
        }

        public IActionResult Details(int id)
        {
            return this.View();
        }

        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(AddConsoleInputModel inputModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(inputModel);
            }

            var consoleId = await this.console.CreateConsoleAsync(inputModel);

            return this.RedirectToAction("Details", new { id = consoleId });
        }

        public IActionResult Browse(int id)
        {
            var consoles = this.console.GetAllByPlatform(id);

            var viewModel = new ListConsolesViewModel { Consoles = consoles };

            return this.View(viewModel);
        }
    }
}
