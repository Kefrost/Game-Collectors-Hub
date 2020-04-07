namespace GameCollectorsHub.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using GameCollectorsHub.Data.Common.Repositories;
    using GameCollectorsHub.Data.Models;
    using GameCollectorsHub.Web.ViewModels.Platform;

    public class PlatformService : IPlatformService
    {
        private readonly IRepository<Platform> repository;

        public PlatformService(IRepository<Platform> repository)
        {
            this.repository = repository;
        }

        public IEnumerable<PlatformDetailsViewModel> GetPlatforms()
        {
            var platforms = this.repository.All().Select(a => new PlatformDetailsViewModel
            {
                Id = a.Id,
                Name = a.Name,
                ImgUrl = a.ImageUrl,
                GamesCount = a.Games.Count(),
                ConsolesCount = a.GameConsoles.Count(),
            }).OrderBy(a => a.Name).ToList();

            return platforms;
        }
    }
}
