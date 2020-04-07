﻿namespace GameCollectorsHub.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using GameCollectorsHub.Data.Common.Repositories;
    using GameCollectorsHub.Data.Models;
    using GameCollectorsHub.Web.ViewModels.Game;

    public class GameService : IGameService
    {
        private readonly IRepository<Game> repository;

        public GameService(IRepository<Game> repository)
        {
            this.repository = repository;
        }

        public async Task<int> CreateGameAsync(AddGameInputModel model)
        {
            var game = new Game
            {
                Name = model.Name,
                Description = model.Description,
                Developer = model.Developer,
                ReleaseDate = model.ReleaseDate,
                Genre = model.Genre,
                ImageUrl = model.ImageUrl,
                PlatformId = model.PlatformId,
                Publisher = model.Publisher,
                Series = model.Series,
            };

            await this.repository.AddAsync(game);

            await this.repository.SaveChangesAsync();

            return game.Id;
        }

        public IEnumerable<ListGameDetailsViewModel> GetAllByPlatform(int id)
        {
            var games = this.repository.All()
                .Where(a => a.Platform.Id == id)
                .Select(a => new ListGameDetailsViewModel
            {
                Id = a.Id,
                Name = a.Name,
                ImgUrl = a.ImageUrl,
                Developer = a.Developer,
                Publisher = a.Publisher,
                ReleaseDate = a.ReleaseDate,
                PlatformName = a.Platform.Name,
            }).OrderBy(a => a.Name).ToList();

            return games;
        }
    }
}