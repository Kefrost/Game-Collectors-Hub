namespace GameCollectorsHub.Services.Data
{
    using System.Collections;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using GameCollectorsHub.Web.ViewModels.Console;
    using GameCollectorsHub.Web.ViewModels.Game;

    public interface IGameService
    {
        public Task<int> CreateGameAsync(AddGameInputModel model);

        public IEnumerable<ListGameDetailsViewModel> GetAllByPlatform(int id);

        public GameDetailsViewModel GetGameDetails(int id);

        public Task EditGameAsync(AddGameInputModel model);

        public Task<int> DeleteGameAsync(int id);

        public IEnumerable<ConsoleLaunchTitlesViewModel> GetLaunchTitles(int id);

        public Task AddGameToCollectionAsync(int gameId, string userId, decimal pricePaid, bool boxIncluded, bool manualIncluded, bool isItNewAndSealed);

        public Task AddGameToWishlistAsync(int gameId, string userId);

        public Task<int> AddRating(string userId, int gameId, int ratingScore, string content);

        public IEnumerable<GameUserRatingViewModel> GetGameUserRatings(int id);

        public IEnumerable<ListGameDetailsViewModel> GetAllBySearchName(string name);

        public Task DeleteRating(int gameId, int ratingId);
    }
}
