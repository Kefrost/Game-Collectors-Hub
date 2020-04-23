namespace GameCollectorsHub.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
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
        private readonly IGameCollectionService colectionService;
        private readonly IGameReviewService reviewService;
        private readonly UserManager<ApplicationUser> userManager;

        public GameController(IPlatformService platform, IGameService gameService, IGameCollectionService colectionService, IGameReviewService reviewService, UserManager<ApplicationUser> userManager)
        {
            this.platform = platform;
            this.gameService = gameService;
            this.colectionService = colectionService;
            this.reviewService = reviewService;
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
            var userId = this.userManager.GetUserId(this.User);

            var viewModel = this.gameService.GetGameDetails(id);

            var reviews = this.reviewService.GetReviewsForGame(id);

            var userRatings = this.gameService.GetGameUserRatings(id);

            viewModel.Reviews = reviews;

            viewModel.OurReviewScore = reviews.Any() ? reviews.Average(a => decimal.Parse(a.OurReviewScore)).ToString() : "N/A";

            viewModel.UserRatingScore = userRatings.Any() ? userRatings.Average(a => a.RatingScore).ToString() : "N/A";

            viewModel.UserRatings = userRatings;

            viewModel.UserId = userId;

            if (!string.IsNullOrEmpty(userId))
            {
                viewModel.IsInCollection = this.colectionService.IsGameInCollection(userId, id);

                viewModel.IsInWishlist = this.colectionService.IsGameInWishlist(userId, id);
            }

            return this.View(viewModel);
        }

        [Authorize(Roles = "Administrator")]
        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Create(AddGameInputModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            var gameId = await this.gameService.CreateGameAsync(model);

            return this.RedirectToAction("Details", new { id = gameId });
        }

        public IActionResult Search(PlatformsViewModel model, int page = 1)
        {
            const int countPerPage = 12;

            var games = this.gameService.GetAllBySearchName(model.SearchString);

            double pages;

            if ((double)(games.Count() % countPerPage) == 0)
            {
                pages = games.Count() / countPerPage;
            }
            else
            {
                pages = Math.Floor((double)(games.Count() / countPerPage));
                pages++;
            }

            games = games.Skip((page - 1) * countPerPage);

            games = games.Take(countPerPage);

            var viewModel = new ListGamesViewModel { Games = games };

            viewModel.PagesCount = (int)pages;
            viewModel.displayName = $"'{model.SearchString}'";

            return this.View("Browse", viewModel);
        }

        public IActionResult Browse(int id, int page = 1)
        {
            const int countPerPage = 12;

            var games = this.gameService.GetAllByPlatform(id);

            double pages;

            if ((double)(games.Count() % countPerPage) == 0)
            {
                pages = games.Count() / countPerPage;
            }
            else
            {
                pages = Math.Floor((double)(games.Count() / countPerPage));
                pages++;
            }

            games = games.Skip((page - 1) * countPerPage);

            games = games.Take(countPerPage);

            var viewModel = new ListGamesViewModel { Games = games };

            viewModel.PagesCount = (int)pages;

            viewModel.displayName = Enum.GetName(typeof(PlatformEnum), id);

            return this.View(viewModel);
        }

        [Authorize(Roles = "Administrator")]
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
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Edit(AddGameInputModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            await this.gameService.EditGameAsync(model);

            return this.RedirectToAction("Details", new { id = model.Id });
        }

        [Authorize(Roles = "Administrator")]
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
        [Authorize(Roles = "Administrator")]
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

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> AddToWishlist(int gameId)
        {
            var user = await this.userManager.GetUserAsync(this.User);

            await this.gameService.AddGameToWishlistAsync(gameId, user.Id);

            return this.Redirect("/GameWishlist/All");
        }

        [Authorize]
        public async Task<IActionResult> AddComment(GameDetailsViewModel model)
        {
            var userId = this.userManager.GetUserId(this.User);

            await this.gameService.AddRating(userId, model.Id, model.AddUserRatingScore, model.AddUserRatingContent);

            return this.RedirectToAction("Details", new { id = model.Id });
        }

        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> DeleteComment(int gameId, int ratingId)
        {
            await this.gameService.DeleteRating(gameId, ratingId);

            return this.RedirectToAction("Details", new { id = gameId });
        }
    }
}
