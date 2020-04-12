﻿namespace GameCollectorsHub.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using GameCollectorsHub.Data.Common.Repositories;
    using GameCollectorsHub.Data.Models;
    using GameCollectorsHub.Web.ViewModels.Console;
    using GameCollectorsHub.Web.ViewModels.Game;
    using GameCollectorsHub.Web.ViewModels.GameCollection;

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

        public GameDetailsViewModel GetGameDetails(int id)
        {
            bool isExist = false;

            if (this.repository.All().Where(a => a.Id == id).Select(a => a.GamesReviews).Any())
            {
                isExist = false;
            }
            else
            {
                isExist = true;
            }

            var game = this.repository.All().Where(a => a.Id == id).Select(a => new GameDetailsViewModel
            {
                Id = a.Id,
                Name = a.Name,
                Description = a.Description,
                Developer = a.Developer,
                Publisher = a.Publisher,
                Genre = a.Genre,
                ImageUrl = a.ImageUrl,
                PlatformName = a.Platform.Name,
                PlatformId = a.PlatformId,
                ReleaseDate = a.ReleaseDate,
                Series = a.Series,
                ReviewImgUrl = a.ImageUrl,
                ReviewId = isExist ? a.GamesReviews.Where(a => a.GameId == id).FirstOrDefault().ReviewId : -1,
                ReviewName = isExist ? a.GamesReviews.Where(a => a.GameId == id).FirstOrDefault().Review.Title : null,
                OurReviewScore = isExist ? a.GamesReviews.Where(a => a.GameId == id).FirstOrDefault().Review.RatingScore.ToString() : null,
                ShortReviewContent = isExist ? a.GamesReviews.Where(a => a.GameId == id).FirstOrDefault().Review.Content.Take(100).ToString() : null,
            }).FirstOrDefault();

            return game;
        }

        public async Task EditGameAsync(AddGameInputModel model)
        {
            var game = this.repository.All().Where(a => a.Id == model.Id).FirstOrDefault();

            game.Name = model.Name;
            game.Description = model.Description;
            game.Developer = model.Developer;
            game.ReleaseDate = model.ReleaseDate;
            game.Genre = model.Genre;
            game.ImageUrl = model.ImageUrl;
            game.PlatformId = model.PlatformId;
            game.Publisher = model.Publisher;
            game.Series = model.Series;

            this.repository.Update(game);
            await this.repository.SaveChangesAsync();
        }

        public async Task<int> DeleteGameAsync(int id)
        {
            var game = this.repository.All().Where(a => a.Id == id).FirstOrDefault();

            this.repository.Delete(game);

            await this.repository.SaveChangesAsync();

            return game.PlatformId;
        }

        public IEnumerable<ConsoleLaunchTitlesViewModel> GetLaunchTitles(int id)
        {
            var launchGames = this.repository.All().Where(a => a.IsLaunchTitle == true && a.PlatformId == id).Select(a => new ConsoleLaunchTitlesViewModel
            {
                Id = a.Id,
                Name = a.Name,
                ImgUrl = a.ImageUrl,
            }).OrderBy(a => a.Name).ToList();

            return launchGames;
        }

        public async Task AddGameToCollectionAsync(int gameId, string userId, decimal pricePaid, bool boxIncluded, bool manualIncluded, bool isItNewAndSealed)
        {
            this.repository.All().Where(a => a.Id == gameId).FirstOrDefault().UserGamesCollection.Add(new UserGameCollection
            {
                GameId = gameId,
                UserId = userId,
                PricePaid = pricePaid,
                BoxIncluded = boxIncluded,
                ManualIncluded = manualIncluded,
                IsItNewAndSealed = isItNewAndSealed,
            });

            await this.repository.SaveChangesAsync();
        }
    }
}
