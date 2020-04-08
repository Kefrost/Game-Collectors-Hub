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

        public ConsoleService(IRepository<GameConsole> repository)
        {
            this.repository = repository;
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
    }
}
