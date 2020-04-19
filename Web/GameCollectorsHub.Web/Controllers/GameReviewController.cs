namespace GameCollectorsHub.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using GameCollectorsHub.Data.Models;
    using GameCollectorsHub.Services.Data;
    using GameCollectorsHub.Web.ViewModels.GameReview;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    public class GameReviewController : Controller
    {
        private readonly IGameService gameService;
        private readonly IGameReviewService reviewService;
        private readonly UserManager<ApplicationUser> userManager;

        public GameReviewController(IGameService gameService, IGameReviewService reviewService, UserManager<ApplicationUser> userManager)
        {
            this.gameService = gameService;
            this.reviewService = reviewService;
            this.userManager = userManager;
        }

        public IActionResult Create(int gameId)
        {
            var game = this.gameService.GetGameDetails(gameId);

            var viewModel = new AddGameReviewInputModel { GameId = gameId, GameImg = game.ImageUrl, GameName = game.Name };

            return this.View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(AddGameReviewInputModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            var reviewId = await this.reviewService.CreateReview(model.GameId, model.Title, model.Content, model.RatingScore);

            return this.RedirectToAction("View", new { id = reviewId });
        }

        public IActionResult View(int id)
        {
            var viewModel = this.reviewService.GetReview(id);

            viewModel.Comments = this.reviewService.GetReviewComments(id);

            return this.View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> AddComment(GameReviewDetailsViewModel model)
        {
            var userId = this.userManager.GetUserId(this.User);

            await this.reviewService.AddComment(userId, model.Id, model.AddCommentContent);

            return this.RedirectToAction("View", new { id = model.Id });
        }

        public IActionResult Edit(int id)
        {
            var review = this.reviewService.GetReview(id);

            var viewModel = new AddGameReviewInputModel
            {
                Id = id,
                GameId = review.GameId,
                GameImg = review.GameImg,
                GameName = review.GameName,
                Content = review.Content,
                Title = review.Title,
                RatingScore = review.RatingScore,
            };

            return this.View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(AddGameReviewInputModel model)
        {
            await this.reviewService.EditReview(model.Id, model.Title, model.RatingScore, model.Content);

            return this.RedirectToAction("View", new { id = model.Id });
        }

        public IActionResult Delete(int id)
        {
            var viewModel = this.reviewService.GetReview(id);

            return this.View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteConfirm(int id)
        {
            var gameId = await this.reviewService.DeleteReviewAsync(id);

            return this.Redirect($"/Game/Details?id={gameId}");
        }
    }
}
