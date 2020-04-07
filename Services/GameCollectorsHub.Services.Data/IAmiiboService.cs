namespace GameCollectorsHub.Services.Data
{
    using System.Collections.Generic;

    using GameCollectorsHub.Web.ViewModels.Amiibo;

    public interface IAmiiboService
    {
        public IEnumerable<AmiiboSeriesDetailsViewModel> GetAmiiboSeries();
    }
}
