namespace GameCollectorsHub.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using GameCollectorsHub.Web.ViewModels.GameCollection;

    public interface IGameCollectionService
    {
        public ICollection<GameCollectionItemViewModel> ListAllGameCollection(string userId);

        public GameCollectionDetailsViewModel GetGameCollectionDetails(string userId, int gameId);

        public Task EditGameInCollection(int gameId, string userId, decimal pricePaid, bool boxIncluded, bool manualIncluded, bool isItNewAndSealed);

        public AddGameToCollectionInputModel GetGameCollectionInputDetails(string userId, int gameId);

        public Task DeleteGameInCollectionAsync(string userId, int gameId);

        public ICollection<GameCollectionItemViewModel> ListAllGameWishlist(string userId);
    }
}
