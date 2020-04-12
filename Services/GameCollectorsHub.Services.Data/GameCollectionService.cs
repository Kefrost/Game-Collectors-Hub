namespace GameCollectorsHub.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;

    using GameCollectorsHub.Data.Common.Repositories;
    using GameCollectorsHub.Data.Models;
    using GameCollectorsHub.Web.ViewModels.GameCollection;

    public class GameCollectionService : IGameCollectionService
    {
        private readonly IRepository<ApplicationUser> userRepository;

        public GameCollectionService(IRepository<ApplicationUser> userRepository)
        {
            this.userRepository = userRepository;
        }

        public ICollection<GameCollectionItemViewModel> ListAllGameCollection(string userId)
        {
            var games = this.userRepository.All().Where(a => a.Id == userId).FirstOrDefault().UserGamesCollection.Select(a => new GameCollectionItemViewModel
            {
                Cost = a.PricePaid,
                GameId = a.GameId,
                GameName = a.Game.Name,
                GameImgUrl = a.Game.ImageUrl,
                PlatformName = a.Game.Platform.Name,
                Value = 50,

                // TODO
            }).OrderBy(a => a.GameName).ToList();

            return games;
        }
    }
}
