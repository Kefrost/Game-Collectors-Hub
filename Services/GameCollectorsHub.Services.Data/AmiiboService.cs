namespace GameCollectorsHub.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;

    using GameCollectorsHub.Data.Common.Repositories;
    using GameCollectorsHub.Data.Models;
    using GameCollectorsHub.Web.ViewModels.Amiibo;

    public class AmiiboService : IAmiiboService
    {
        private readonly IRepository<AmiiboSeries> seriesRepository;

        public AmiiboService(IRepository<AmiiboSeries> seriesRepository)
        {
            this.seriesRepository = seriesRepository;
        }

        public IEnumerable<AmiiboSeriesDetailsViewModel> GetAmiiboSeries()
        {
            var series = this.seriesRepository.All().Select(a => new AmiiboSeriesDetailsViewModel
            {
                Name = a.Name,
                ImgUrl = a.ImgUrl,
                AmiibosCount = a.Amiibos.Count(),
            }).OrderBy(a => a.Name).ToList();

            return series;
        }
    }
}
