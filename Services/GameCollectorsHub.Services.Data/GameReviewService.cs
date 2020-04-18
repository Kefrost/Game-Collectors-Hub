namespace GameCollectorsHub.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using GameCollectorsHub.Data.Common.Repositories;
    using GameCollectorsHub.Data.Models;
    using GameCollectorsHub.Web.ViewModels.Game;
    using GameCollectorsHub.Web.ViewModels.GameReview;

    public class GameReviewService : IGameReviewService
    {
        private readonly IRepository<Review> repository;

        public GameReviewService(IRepository<Review> repository)
        {
            this.repository = repository;
        }

        public async Task<int> CreateReview(int gameId, string title, string content, int ratingScore)
        {
            var review = new Review
            {
                GameId = gameId,
                RatingScore = ratingScore,
                Title = title,
                Content = content,
            };

            await this.repository.AddAsync(review);

            await this.repository.SaveChangesAsync();

            return review.Id;
        }

        public GameReviewDetailsViewModel GetReview(int id)
        {
            var review = this.repository.All().Where(a => a.Id == id).Select(a => new GameReviewDetailsViewModel
            {
                Id = id,
                GameId = a.GameId,
                GameImg = a.Game.ImageUrl,
                GameName = a.Game.Name,
                Content = a.Content,
                RatingScore = a.RatingScore,
                Title = a.Title,
                Comments = a.Comments,
            }).FirstOrDefault();

            return review;
        }

        public async Task EditReview(int id, string title, int score, string content)
        {
            var review = this.repository.All().Where(a => a.Id == id).FirstOrDefault();

            review.Title = title;
            review.RatingScore = score;
            review.Content = content;

            this.repository.Update(review);

            await this.repository.SaveChangesAsync();
        }

        public async Task<int> DeleteReviewAsync(int id)
        {
            var review = this.repository.All().Where(a => a.Id == id).FirstOrDefault();

            this.repository.Delete(review);

            await this.repository.SaveChangesAsync();

            return review.GameId;
        }

        public IEnumerable<GameDetailsReviewViewModel> GetReviewsForGame(int id)
        {
            var reviews = this.repository.All().Where(a => a.GameId == id).Select(a => new GameDetailsReviewViewModel
            {
                ReviewId = a.Id,
                ReviewImgUrl = a.Game.ImageUrl,
                ReviewName = a.Title,
                ReviewContent = a.Content,
                OurReviewScore = a.RatingScore.ToString(),
            }).ToList();

            //a.Content.Length > 300 ? a.Content.Substring(0, 300) : a.Content

            return reviews;
        }
    }
}
