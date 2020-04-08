namespace GameCollectorsHub.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using GameCollectorsHub.Data.Common.Repositories;
    using GameCollectorsHub.Data.Models;
    using GameCollectorsHub.Web.ViewModels.Amiibo;

    public class AmiiboService : IAmiiboService
    {
        private readonly IRepository<AmiiboSeries> seriesRepository;
        private readonly IRepository<Amiibo> amiiboRepository;

        public AmiiboService(IRepository<AmiiboSeries> seriesRepository, IRepository<Amiibo> amiiboRepository)
        {
            this.seriesRepository = seriesRepository;
            this.amiiboRepository = amiiboRepository;
        }

        public IEnumerable<AmiiboSeriesDetailsViewModel> GetAmiiboSeries()
        {
            var series = this.seriesRepository.All().Select(a => new AmiiboSeriesDetailsViewModel
            {
                Id = a.Id,
                Name = a.Name,
                ImgUrl = a.ImgUrl,
                AmiibosCount = a.Amiibos.Count(),
            }).OrderBy(a => a.Name).ToList();

            return series;
        }

        public async Task<int> CreateAmiiboAsync(AddAmiiboInputModel model)
        {
            var amiibo = new Amiibo
            {
                Name = model.Name,
                Description = model.Description,
                ImgUrl = model.ImgUrl,
                ReleaseDate = model.ReleaseDate,
                Franchise = model.Franchise,
                AmiiboSeriesId = model.AmiiboSeriesId,
            };

            await this.amiiboRepository.AddAsync(amiibo);

            await this.amiiboRepository.SaveChangesAsync();

            return amiibo.Id;
        }

        public IEnumerable<AllAmiiboDetailsViewModel> GetAllBySeries(int id)
        {
            var amiibos = this.amiiboRepository.All().Where(a => a.AmiiboSeriesId == id).Select(a => new AllAmiiboDetailsViewModel
            {
                Id = a.Id,
                Name = a.Name,
                ImgUrl = a.ImgUrl,
                Franchise = a.Franchise,
                ReleaseDate = a.ReleaseDate,
                SeriesName = a.AmiiboSeries.Name,
            }).OrderBy(a => a.Name).ToList();

            return amiibos;
        }
    }
}
