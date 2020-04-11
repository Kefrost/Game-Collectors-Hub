namespace GameCollectorsHub.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using GameCollectorsHub.Web.ViewModels.Amiibo;

    public interface IAmiiboService
    {
        public IEnumerable<AmiiboSeriesDetailsViewModel> GetAmiiboSeries();

        public Task<int> CreateAmiiboAsync(AddAmiiboInputModel model);

        public IEnumerable<AllAmiiboDetailsViewModel> GetAllBySeries(int id);

        public Task EditAmiiboAsync(AddAmiiboInputModel model);

        public AmiiboDetailsViewModel GetAmiiboDetails(int id);

        public Task<int> DeleteAmiiboAsync(int id);
    }
}
