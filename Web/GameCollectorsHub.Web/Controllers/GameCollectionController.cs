namespace GameCollectorsHub.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using GameCollectorsHub.Data.Models;
    using GameCollectorsHub.Services.Data;
    using GameCollectorsHub.Web.ViewModels.GameCollection;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    public class GameCollectionController : Controller
    {
        private readonly IGameCollectionService service;
        private readonly UserManager<ApplicationUser> userManager;

        public GameCollectionController(IGameCollectionService service, UserManager<ApplicationUser> userManager)
        {
            this.service = service;
            this.userManager = userManager;
        }

        public async Task<IActionResult> AllCollection()
        {
            var user = await this.userManager.GetUserAsync(this.User);

            var games = this.service.ListAllGameCollection(user.Id);

            var value = 0.0m;

            foreach (var game in games)
            {
                var resValue = 0.0m;
                var parse = decimal.TryParse(game.Value.Replace("\n", string.Empty).Replace('$', ' ').Trim(), out resValue);
                value += resValue;
            }

            var viewModel = new AllGameCollectionViewModel
            {
                GameCollectionItems = games,
                CollectionValue = value,
                TotalYouPaid = games.Sum(a => a.Cost),
            };

            viewModel.CollectionValue = Math.Round(viewModel.CollectionValue, 3);
            viewModel.TotalYouPaid = Math.Round(viewModel.TotalYouPaid, 3);
            return this.View(viewModel);
        }

        public async Task<IActionResult> Details(int gameId)
        {
            var user = await this.userManager.GetUserAsync(this.User);

            var viewModel = this.service.GetGameCollectionDetails(user.Id, gameId);

            return this.View(viewModel);
        }

        public async Task<IActionResult> Edit(int gameId)
        {
            var user = await this.userManager.GetUserAsync(this.User);

            var game = this.service.GetGameCollectionInputDetails(user.Id, gameId);

            var viewModel = new AddGameToCollectionInputModel
            {
                GameId = gameId,
                GameImgUrl = game.GameImgUrl,
                GameName = game.GameName,
                BoxIncluded = game.BoxIncluded,
                IsItNewAndSealed = game.IsItNewAndSealed,
                ManualIncluded = game.ManualIncluded,
                PricePaid = game.PricePaid,
            };

            return this.View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(AddGameToCollectionInputModel model)
        {
            var user = await this.userManager.GetUserAsync(this.User);

            await this.service.EditGameInCollection(model.GameId, user.Id, model.PricePaid, model.BoxIncluded, model.ManualIncluded, model.IsItNewAndSealed);

            return this.RedirectToAction("Details", new { gameId = model.GameId });
        }

        public async Task<IActionResult> Delete(int gameId)
        {
            var user = await this.userManager.GetUserAsync(this.User);

            var game = this.service.GetGameCollectionInputDetails(user.Id, gameId);

            var viewModel = new AddGameToCollectionInputModel
            {
                GameId = game.GameId,
                BoxIncluded = game.BoxIncluded,
                GameImgUrl = game.GameImgUrl,
                GameName = game.GameName,
                IsItNewAndSealed = game.IsItNewAndSealed,
                ManualIncluded = game.ManualIncluded,
                PricePaid = game.PricePaid,
            };

            return this.View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteConfirm(int gameId)
        {
            var user = await this.userManager.GetUserAsync(this.User);

            await this.service.DeleteGameInCollectionAsync(user.Id, gameId);

            return this.RedirectToAction("AllCollection", new { userId = user.Id });
        }
    }
}
