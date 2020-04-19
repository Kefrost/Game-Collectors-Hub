namespace GameCollectorsHub.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using GameCollectorsHub.Web.ViewModels.Game;
    using GameCollectorsHub.Web.ViewModels.GameReview;

    public interface IGameReviewService
    {
        public Task<int> CreateReview(int gameId, string title, string content, int ratingScore);

        public GameReviewDetailsViewModel GetReview(int id);

        public Task EditReview(int id, string title, int score, string content);

        public Task<int> DeleteReviewAsync(int id);

        public IEnumerable<GameDetailsReviewViewModel> GetReviewsForGame(int id);

        public Task<int> AddComment(string userId, int reviewId, string content);

        public IEnumerable<ReviewCommentViewModel> GetReviewComments(int id);
    }
}
