namespace GameCollectorsHub.Services.Data
{
    using GameCollectorsHub.Web.ViewModels.ScrapeData;

    public interface IScrapeService
    {
        public PriceScrapeDataViewModel GetPrices(string url);
    }
}
