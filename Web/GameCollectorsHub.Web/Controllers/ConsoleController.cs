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
            var viewModel = this.console.GetConsoleDetails(id);

            return this.View(viewModel);
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

        public IActionResult Edit(int id)
        {
            var console = this.console.GetConsoleDetails(id);

            var viewModel = new AddConsoleInputModel
            {
                Id = id,
                Name = console.Name,
                Description = console.Description,
                ImgUrl = console.ImgUrl,
                ReleaseDate = console.ReleaseDate,
                PlatformId = console.PlatformId,
                GamesReleased = console.GamesReleased,
                Model = console.Model,
                InitialPrice = console.InitialPrice,
            };

            return this.View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(AddConsoleInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(input);
            }

            await this.console.EditConsoleAsync(input);

            return this.RedirectToAction("Details", new { id = input.Id });
        }

        public IActionResult Delete(int id)
        {
            var console = this.console.GetConsoleDetails(id);

            var viewModel = new AddConsoleInputModel
            {
                Id = id,
                Name = console.Name,
                Description = console.Description,
                Model = console.Model,
                GamesReleased = console.GamesReleased,
                ImgUrl = console.ImgUrl,
                ReleaseDate = console.ReleaseDate,
                InitialPrice = console.InitialPrice,
                PlatformId = console.PlatformId,
            };

            return this.View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteConfirm(int id)
        {
            var platformId = await this.console.DeleteConsoleAsync(id);

            return this.RedirectToAction("Browse", new { id = platformId });
        }
    }
}
