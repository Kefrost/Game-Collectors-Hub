using GameCollectorsHub.Web.ViewModels.GameCollection;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GameCollectorsHub.Services.Data
{
    public interface IGameCollectionService
    {
        public ICollection<GameCollectionItemViewModel> ListAllGameCollection(string userId);

        public GameCollectionDetailsViewModel GetGameCollectionDetails(string userId, int gameId);

        public Task EditGameInCollection(int gameId, string userId, decimal pricePaid, bool boxIncluded, bool manualIncluded, bool isItNewAndSealed);

        public AddGameToCollectionInputModel GetGameCollectionInputDetails(string userId, int gameId);
    }
}
