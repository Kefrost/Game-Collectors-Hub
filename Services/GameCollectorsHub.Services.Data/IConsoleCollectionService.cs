namespace GameCollectorsHub.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using GameCollectorsHub.Web.ViewModels.ConsoleCollection;

    public interface IConsoleCollectionService
    {
        public ICollection<ConsoleCollectionItemViewModel> ListAllConsolesCollection(string userId);

        public ICollection<ConsoleCollectionItemViewModel> ListAllConsolesWishlist(string userId);

        public ConsoleCollectionDetailsViewModel GetConsoleCollectionDetails(string userId, int consoleId);

        public Task EditConsoleInCollection(int consoleId, string userId, decimal pricePaid, bool boxIncluded, bool isItNewAndSealed);

        public AddConsoleToCollectionInputModel GetConsoleCollectionInputDetails(string userId, int consoleId);

        public Task DeleteConsoleInCollectionAsync(string userId, int consoleId);
    }
}
