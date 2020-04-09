namespace GameCollectorsHub.Services.Data
{
    using System.Collections;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using GameCollectorsHub.Web.ViewModels.Game;

    public interface IGameService
    {
        public Task<int> CreateGameAsync(AddGameInputModel model);

        public IEnumerable<ListGameDetailsViewModel> GetAllByPlatform(int id);

        public GameDetailsViewModel GetGameDetails(int id);
    }
}
