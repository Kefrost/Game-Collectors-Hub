﻿namespace GameCollectorsHub.Web.Controllers
    {
    using System.Threading.Tasks;

    using GameCollectorsHub.Services.Data;
    using GameCollectorsHub.Web.ViewModels.Game;
    using GameCollectorsHub.Web.ViewModels.Platform;

    using Microsoft.AspNetCore.Mvc;

    public class GameController : Controller
    {
        private readonly IPlatformService platform;
        private readonly IGameService gameService;

        public GameController(IPlatformService platform, IGameService gameService)
        {
            this.platform = platform;
            this.gameService = gameService;
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
    }
}