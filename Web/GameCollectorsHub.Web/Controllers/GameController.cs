namespace GameCollectorsHub.Web.Controllers
    {
    using System.Threading.Tasks;
    using GameCollectorsHub.Data.Models;
    using GameCollectorsHub.Services.Data;
    using GameCollectorsHub.Web.ViewModels.Game;
    using GameCollectorsHub.Web.ViewModels.GameCollection;
    using GameCollectorsHub.Web.ViewModels.Platform;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    public class GameController : Controller
    {
        private readonly IPlatformService platform;
        private readonly IGameService gameService;
        private readonly UserManager<ApplicationUser> userManager;

        public GameController(IPlatformService platform, IGameService gameService, UserManager<ApplicationUser> userManager)
        {
            this.platform = platform;
            this.gameService = gameService;
            this.userManager = userManager;
        }

        public IActionResult Platforms()
        {
            var platforms = this.platform.GetPlatforms();

            var viewModel = new PlatformsViewModel { Platforms = platforms };

            return this.View(viewModel);
        }

        public IActionResult Details(int id)
        {
            var viewModel = this.gameService.GetGameDetails(id);

            if (viewModel.OurReviewScore == null)
            {
                viewModel.OurReviewScore = "N/A";
            }

            return this.View(viewModel);
        }

        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(AddGameInputModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            var gameId = await this.gameService.CreateGameAsync(model);

            return this.RedirectToAction("Details", new { id = gameId });
        }

        public IActionResult Browse(int id)
        {
            var games = this.gameService.GetAllByPlatform(id);

            var viewModel = new ListGamesViewModel { Games = games };

            return this.View(viewModel);
        }

        public IActionResult Edit(int id)
        {
            var game = this.gameService.GetGameDetails(id);

            var viewModel = new AddGameInputModel
            {
                Id = id,
                Name = game.Name,
                Description = game.Description,
                Developer = game.Developer,
                Publisher = game.Publisher,
                ImageUrl = game.ImageUrl,
                ReleaseDate = game.ReleaseDate,
                Genre = game.Genre,
                Series = game.Series,
                PlatformId = game.PlatformId,
            };

            return this.View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(AddGameInputModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            await this.gameService.EditGameAsync(model);

            return this.RedirectToAction("Details", new { id = model.Id });
        }

        public IActionResult Delete(int id)
        {
            var game = this.gameService.GetGameDetails(id);

            var viewModel = new AddGameInputModel
            {
                Id = id,
                Name = game.Name,
                Description = game.Description,
                Developer = game.Developer,
                Publisher = game.Publisher,
                ImageUrl = game.ImageUrl,
                ReleaseDate = game.ReleaseDate,
                Genre = game.Genre,
                Series = game.Series,
                PlatformId = game.PlatformId,
            };

            return this.View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteConfirm(int id)
        {
            var platformId = await this.gameService.DeleteGameAsync(id);

            return this.RedirectToAction("Browse", new { id = platformId });
        }

        [Authorize]
        public IActionResult AddToCollection(int gameId)
        {
            var game = this.gameService.GetGameDetails(gameId);

            var viewModel = new AddGameToCollectionInputModel { GameId = gameId, GameImgUrl = game.ImageUrl, GameName = game.Name, };

            return this.View(viewModel);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> AddToCollection(AddGameToCollectionInputModel model)
        {
            var user = await this.userManager.GetUserAsync(this.User);

            await this.gameService.AddGameToCollectionAsync(model.GameId, user.Id, model.PricePaid, model.BoxIncluded, model.ManualIncluded, model.IsItNewAndSealed);

            return this.RedirectToAction("Details", new { id = model.GameId });
        }
    }
}
