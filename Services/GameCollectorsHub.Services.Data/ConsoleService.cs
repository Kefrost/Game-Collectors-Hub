namespace GameCollectorsHub.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using GameCollectorsHub.Data.Common.Repositories;
    using GameCollectorsHub.Data.Models;
    using GameCollectorsHub.Web.ViewModels.Console;

    public class ConsoleService : IConsoleService
    {
        private readonly IRepository<GameConsole> repository;
        private readonly IRepository<UserConsoleCollection> collectionRepository;
        private readonly IGameService gameService;

        public ConsoleService(IRepository<GameConsole> repository, IRepository<UserConsoleCollection> collectionRepository, IGameService gameService)
        {
            this.repository = repository;
            this.collectionRepository = collectionRepository;
            this.gameService = gameService;
        }

        public async Task<int> CreateConsoleAsync(AddConsoleInputModel model)
        {
            var console = new GameConsole
            {
                Name = model.Name,
                Description = model.Description,
                ImgUrl = model.ImgUrl,
                InitialPrice = model.InitialPrice,
                Model = model.Model,
                ReleaseDate = model.ReleaseDate,
                PlatformId = model.PlatformId,
            };

            await this.repository.AddAsync(console);

            await this.repository.SaveChangesAsync();

            return console.Id;
        }

        public IEnumerable<ListConsoleDetailsViewModel> GetAllByPlatform(int id)
        {
            var consoles = this.repository.All().Where(a => a.PlatformId == id).Select(a => new ListConsoleDetailsViewModel
            {
                Id = a.Id,
                Name = a.Name,
                Model = a.Model,
                ImgUrl = a.ImgUrl,
                PlatformName = a.Platform.Name,
                ReleaseDate = a.ReleaseDate,
            }).OrderBy(a => a.Name).ToList();

            return consoles;
        }

        public ConsoleDetailsViewModel GetConsoleDetails(int id)
        {
            var console = this.repository.All().Where(a => a.Id == id).Select(a => new ConsoleDetailsViewModel
            {
                Id = a.Id,
                Name = a.Name,
                Description = a.Description,
                GamesReleased = a.GamesReleased,
                ImgUrl = a.ImgUrl,
                InitialPrice = a.InitialPrice,
                Model = a.Model,
                PlatformId = a.PlatformId,
                ReleaseDate = a.ReleaseDate,
                LauchTitles = this.gameService.GetLaunchTitles(a.PlatformId),
            }).FirstOrDefault();

            return console;
        }

        public async Task EditConsoleAsync(AddConsoleInputModel model)
        {
            var console = this.repository.All().Where(a => a.Id == model.Id).FirstOrDefault();

            console.Name = model.Name;
            console.Description = model.Description;
            console.ImgUrl = model.ImgUrl;
            console.PlatformId = model.PlatformId;
            console.GamesReleased = model.GamesReleased;
            console.InitialPrice = model.InitialPrice;
            console.Model = model.Model;
            console.ReleaseDate = model.ReleaseDate;

            this.repository.Update(console);
            await this.repository.SaveChangesAsync();
        }

        public async Task<int> DeleteConsoleAsync(int id)
        {
            var console = this.repository.All().Where(a => a.Id == id).FirstOrDefault();

            this.repository.Delete(console);

            await this.repository.SaveChangesAsync();

            return console.PlatformId;
        }

        public async Task AddConsoleToCollectionAsync(int consoleId, string userId, decimal pricePaid, bool boxIncluded, bool isItNewAndSealed)
        {
            if (this.collectionRepository.All().Where(a => a.GameConsoleId == consoleId && a.UserId == userId).Any())
            {
                var console = this.collectionRepository.All().Where(a => a.GameConsoleId == consoleId && a.UserId == userId).FirstOrDefault();

                console.IsInWishlist = false;

                this.collectionRepository.Update(console);

                await this.collectionRepository.SaveChangesAsync();
            }
            else
            {
                this.repository.All().Where(a => a.Id == consoleId).FirstOrDefault().UserConsolesCollection.Add(new UserConsoleCollection
                {
                    GameConsoleId = consoleId,
                    UserId = userId,
                    PricePaid = pricePaid,
                    BoxIncluded = boxIncluded,
                    IsItNewAndSealed = isItNewAndSealed,
                    IsInWishlist = false,
                });

                await this.repository.SaveChangesAsync();
            }
        }

        public async Task AddConsoleToWishlistAsync(int consoleId, string userId)
        {
            if (this.collectionRepository.All().Where(a => a.GameConsoleId == consoleId && a.UserId == userId).Any())
            {
                var console = this.collectionRepository.All().Where(a => a.GameConsoleId == consoleId && a.UserId == userId).FirstOrDefault();

                console.IsInWishlist = true;

                this.collectionRepository.Update(console);

                await this.collectionRepository.SaveChangesAsync();
            }
            else
            {
                this.repository.All().Where(a => a.Id == consoleId).FirstOrDefault().UserConsolesCollection.Add(new UserConsoleCollection
                {
                    GameConsoleId = consoleId,
                    UserId = userId,
                    PricePaid = 0,
                    BoxIncluded = false,
                    IsItNewAndSealed = false,
                    IsInWishlist = true,
                });

                await this.repository.SaveChangesAsync();
            }
        }
    }
}
