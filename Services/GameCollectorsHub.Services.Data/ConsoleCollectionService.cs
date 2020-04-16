namespace GameCollectorsHub.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using GameCollectorsHub.Data.Common.Repositories;
    using GameCollectorsHub.Data.Models;
    using GameCollectorsHub.Web.ViewModels.ConsoleCollection;

    public class ConsoleCollectionService : IConsoleCollectionService
    {
        private readonly IRepository<UserConsoleCollection> repository;

        public ConsoleCollectionService(IRepository<UserConsoleCollection> repository)
        {
            this.repository = repository;
        }

        public ICollection<ConsoleCollectionItemViewModel> ListAllConsolesCollection(string userId)
        {
            var consoles = this.repository.All().Where(a => a.UserId == userId && a.IsInWishlist == false).Select(a => new ConsoleCollectionItemViewModel
            {
                Cost = a.PricePaid,
                ConsoleId = a.GameConsoleId,
                ConsoleImgUrl = a.GameConsole.ImgUrl,
                ConsoleName = a.GameConsole.Name,
                Model = a.GameConsole.Model,

                // TODO
            }).OrderBy(a => a.ConsoleName).ToList();

            return consoles;
        }

        public ICollection<ConsoleCollectionItemViewModel> ListAllConsolesWishlist(string userId)
        {
            var consoles = this.repository.All().Where(a => a.UserId == userId && a.IsInWishlist == true).Select(a => new ConsoleCollectionItemViewModel
            {
                ConsoleName = a.GameConsole.Name,
                ConsoleImgUrl = a.GameConsole.ImgUrl,
                ConsoleId = a.GameConsoleId,
                Cost = a.PricePaid,
                Model = a.GameConsole.Model,

                // TODO
            }).OrderBy(a => a.ConsoleName).ToList();

            return consoles;
        }

        public ConsoleCollectionDetailsViewModel GetConsoleCollectionDetails(string userId, int consoleId)
        {
            var includes = "Console only";

            var console = this.repository.All().Where(a => a.GameConsoleId == consoleId && a.UserId == userId).FirstOrDefault();

            if (console.BoxIncluded)
            {
                includes = "Console and box";
            }

            var consoleReturn = this.repository.All().Where(a => a.GameConsoleId == consoleId && a.UserId == userId).Select(a => new ConsoleCollectionDetailsViewModel
            {
                ConsoleId = a.GameConsoleId,
                ConsoleImgUrl = a.GameConsole.ImgUrl,
                ConsoleName = a.GameConsole.Name,
                Condition = a.IsItNewAndSealed ? "New and Sealed" : "Normal wear",
                Cost = a.PricePaid,
                Model = a.GameConsole.Model,
                WhatIncludes = includes,
            }).FirstOrDefault();

            return consoleReturn;
        }

        public async Task EditConsoleInCollection(int consoleId, string userId, decimal pricePaid, bool boxIncluded, bool isItNewAndSealed)
        {
            var console = this.repository.All().Where(a => a.UserId == userId && a.GameConsoleId == consoleId).FirstOrDefault();

            console.PricePaid = pricePaid;
            console.BoxIncluded = boxIncluded;
            console.IsItNewAndSealed = isItNewAndSealed;
            console.IsInWishlist = false;

            this.repository.Update(console);

            await this.repository.SaveChangesAsync();
        }

        public AddConsoleToCollectionInputModel GetConsoleCollectionInputDetails(string userId, int consoleId)
        {
            var consoleReturn = this.repository.All().Where(a => a.GameConsoleId == consoleId && a.UserId == userId).Select(a => new AddConsoleToCollectionInputModel
            {
                ConsoleId = a.GameConsoleId,
                ConsoleImgUrl = a.GameConsole.ImgUrl,
                ConsoleName = a.GameConsole.Name,
                BoxIncluded = a.BoxIncluded,
                IsItNewAndSealed = a.IsItNewAndSealed,
                PricePaid = a.PricePaid,
            }).FirstOrDefault();

            return consoleReturn;
        }

        public async Task DeleteConsoleInCollectionAsync(string userId, int consoleId)
        {
            var console = this.repository.All().Where(a => a.UserId == userId && a.GameConsoleId == consoleId).FirstOrDefault();

            this.repository.Delete(console);

            await this.repository.SaveChangesAsync();
        }
    }
}
