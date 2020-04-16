namespace GameCollectorsHub.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using GameCollectorsHub.Web.ViewModels.Console;

    public interface IConsoleService
    {
        public Task<int> CreateConsoleAsync(AddConsoleInputModel model);

        public IEnumerable<ListConsoleDetailsViewModel> GetAllByPlatform(int id);

        public ConsoleDetailsViewModel GetConsoleDetails(int id);

        public Task EditConsoleAsync(AddConsoleInputModel model);

        public Task<int> DeleteConsoleAsync(int id);

        public Task AddConsoleToCollectionAsync(int consoleId, string userId, decimal pricePaid, bool boxIncluded, bool isItNewAndSealed);

        public Task AddConsoleToWishlistAsync(int consoleId, string userId);
    }
}
