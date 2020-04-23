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
        private readonly IDeletableEntityRepository<Comment> commentRepository;

        public GameReviewService(IRepository<Review> repository, IDeletableEntityRepository<Comment> commentRepository)
        {
            this.repository = repository;
            this.commentRepository = commentRepository;
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
            }).FirstOrDefault();

            return review;
        }

        public IEnumerable<ReviewCommentViewModel> GetReviewComments(int id)
        {
            var comments = this.commentRepository.All().Where(a => a.ReviewId == id).OrderByDescending(a => a.CreatedOn).Select(a => new ReviewCommentViewModel
            {
                Id = a.Id,
                CreatedOn = a.CreatedOn,
                UserId = a.UserId,
                UserName = a.User.UserName,
                Content = a.Content,
            }).ToList();

            return comments;
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

            return reviews;
        }

        public async Task<int> AddComment(string userId, int reviewId, string content)
        {
            var comment = new Comment
            {
                Content = content,
                ReviewId = reviewId,
                UserId = userId,
            };

            await this.commentRepository.AddAsync(comment);

            await this.commentRepository.SaveChangesAsync();

            return comment.ReviewId;
        }

        public async Task DeleteComment(int reviewId, int commentId)
        {
            var rating = this.commentRepository.All().Where(a => a.Id == commentId && a.ReviewId == reviewId).FirstOrDefault();

            rating.IsDeleted = true;

            this.commentRepository.Update(rating);

            await this.commentRepository.SaveChangesAsync();
        }
    }
}
