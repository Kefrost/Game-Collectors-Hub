﻿namespace GameCollectorsHub.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using GameCollectorsHub.Data.Common.Repositories;
    using GameCollectorsHub.Data.Models;
    using GameCollectorsHub.Web.ViewModels.GameCollection;

    public class GameCollectionService : IGameCollectionService
    {
        private readonly IRepository<UserGameCollection> repository;
        private readonly IScrapeService scrapeService;

        public GameCollectionService(IRepository<UserGameCollection> repository, IScrapeService scrapeService)
        {
            this.repository = repository;
            this.scrapeService = scrapeService;
        }

        public ICollection<GameCollectionItemViewModel> ListAllGameCollection(string userId)
        {
            var games = this.repository.All().Where(a => a.UserId == userId && a.IsInWishlist == false).Select(a => new GameCollectionItemViewModel
            {
                Cost = a.PricePaid,
                GameId = a.GameId,
                GameName = a.Game.Name,
                GameImgUrl = a.Game.ImageUrl,
                PlatformName = a.Game.Platform.Name,
                Value = a.IsItNewAndSealed ? this.scrapeService.GetPrices(a.Game.PriceUrl).NewPrice : a.BoxIncluded && a.ManualIncluded ? this.scrapeService.GetPrices(a.Game.PriceUrl).CompletePrice : this.scrapeService.GetPrices(a.Game.PriceUrl).UsedPrice,
            }).OrderBy(a => a.GameName).ToList();

            return games;
        }

        public ICollection<GameCollectionItemViewModel> ListAllGameWishlist(string userId)
        {
            var games = this.repository.All().Where(a => a.UserId == userId && a.IsInWishlist == true).Select(a => new GameCollectionItemViewModel
            {
                GameId = a.GameId,
                GameName = a.Game.Name,
                GameImgUrl = a.Game.ImageUrl,
                PlatformName = a.Game.Platform.Name,
                Cost = a.PricePaid,
            }).OrderBy(a => a.GameName).ToList();

            return games;
        }

        public GameCollectionDetailsViewModel GetGameCollectionDetails(string userId, int gameId)
        {
            var includes = "Game only";

            var game = this.repository.All().Where(a => a.GameId == gameId && a.UserId == userId).FirstOrDefault();

            if (game.BoxIncluded && game.ManualIncluded)
            {
                includes = "Game, Box, Manual";
            }
            else if (game.BoxIncluded)
            {
                includes = "Game, Box";
            }
            else if (game.ManualIncluded)
            {
                includes = "Game, Manual";
            }

            var gameReturn = this.repository.All().Where(a => a.GameId == gameId && a.UserId == userId).Select(a => new GameCollectionDetailsViewModel
            {
                GameId = a.GameId,
                GameImgUrl = a.Game.ImageUrl,
                Condition = a.IsItNewAndSealed ? "New and Sealed" : "Normal wear",
                Cost = a.PricePaid,
                GameName = a.Game.Name,
                PlatformName = a.Game.Platform.Name,
                Value = a.IsItNewAndSealed ? this.scrapeService.GetPrices(a.Game.PriceUrl).NewPrice : a.BoxIncluded && a.ManualIncluded ? this.scrapeService.GetPrices(a.Game.PriceUrl).CompletePrice : this.scrapeService.GetPrices(a.Game.PriceUrl).UsedPrice,
                WhatIncludes = includes,
            }).FirstOrDefault();

            return gameReturn;
        }

        public async Task EditGameInCollection(int gameId, string userId, decimal pricePaid, bool boxIncluded, bool manualIncluded, bool isItNewAndSealed)
        {
            var game = this.repository.All().Where(a => a.UserId == userId && a.GameId == gameId).FirstOrDefault();

            game.PricePaid = pricePaid;
            game.BoxIncluded = boxIncluded;
            game.ManualIncluded = manualIncluded;
            game.IsItNewAndSealed = isItNewAndSealed;
            game.IsInWishlist = false;

            this.repository.Update(game);

            await this.repository.SaveChangesAsync();
        }

        public AddGameToCollectionInputModel GetGameCollectionInputDetails(string userId, int gameId)
        {
            var gameReturn = this.repository.All().Where(a => a.GameId == gameId && a.UserId == userId).Select(a => new AddGameToCollectionInputModel
            {
                GameId = a.GameId,
                GameImgUrl = a.Game.ImageUrl,
                GameName = a.Game.Name,
                BoxIncluded = a.BoxIncluded,
                IsItNewAndSealed = a.IsItNewAndSealed,
                ManualIncluded = a.ManualIncluded,
                PricePaid = a.PricePaid,
            }).FirstOrDefault();

            return gameReturn;
        }

        public async Task DeleteGameInCollectionAsync(string userId, int gameId)
        {
            var game = this.repository.All().Where(a => a.UserId == userId && a.GameId == gameId).FirstOrDefault();

            this.repository.Delete(game);

            await this.repository.SaveChangesAsync();
        }

        public bool IsGameInCollection(string userId, int gameId)
        {
            var game = this.repository.All().Where(a => a.GameId == gameId && a.UserId == userId && a.IsInWishlist == false).FirstOrDefault();

            if (game != null)
            {
                return true;
            }

            return false;
        }

        public bool IsGameInWishlist(string userId, int gameId)
        {
            var game = this.repository.All().Where(a => a.GameId == gameId && a.UserId == userId && a.IsInWishlist == true).FirstOrDefault();

            if (game != null)
            {
                return true;
            }

            return false;
        }
    }
}
