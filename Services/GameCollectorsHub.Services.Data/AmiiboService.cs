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
        private readonly IRepository<UserAmiiboCollection> collectionRepository;
        private readonly IRepository<Amiibo> amiiboRepository;
        private readonly IScrapeService scrapeService;

        public AmiiboService(IRepository<AmiiboSeries> seriesRepository, IRepository<UserAmiiboCollection> collectionRepository, IRepository<Amiibo> amiiboRepository, IScrapeService scrapeService)
        {
            this.seriesRepository = seriesRepository;
            this.collectionRepository = collectionRepository;
            this.amiiboRepository = amiiboRepository;
            this.scrapeService = scrapeService;
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
                PriceUrl = model.PriceUrl,
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

        public IEnumerable<AllAmiiboDetailsViewModel> GetAllByFranchise(string franchise)
        {
            var franchiseAmiibos = this.amiiboRepository.All().Where(a => a.Franchise == franchise).OrderBy(a => a.Name).Select(a => new AllAmiiboDetailsViewModel
            {
                Id = a.Id,
                Name = a.Name,
                ImgUrl = a.ImgUrl,
                Franchise = a.Franchise,
            }).ToList();

            return franchiseAmiibos;
        }

        public async Task EditAmiiboAsync(AddAmiiboInputModel model)
        {
            var amiibo = this.amiiboRepository.All().Where(a => a.Id == model.Id).FirstOrDefault();

            amiibo.Name = model.Name;
            amiibo.Description = model.Description;
            amiibo.ImgUrl = model.ImgUrl;
            amiibo.ReleaseDate = model.ReleaseDate;
            amiibo.AmiiboSeriesId = model.AmiiboSeriesId;
            amiibo.Franchise = model.Franchise;
            amiibo.PriceUrl = model.PriceUrl;

            this.amiiboRepository.Update(amiibo);
            await this.amiiboRepository.SaveChangesAsync();
        }

        public AmiiboDetailsViewModel GetAmiiboDetails(int id)
        {
            var priceUrl = this.amiiboRepository.All().Where(a => a.Id == id).Select(a => a.PriceUrl).FirstOrDefault();

            var amiibo = this.amiiboRepository.All().Where(a => a.Id == id).Select(a => new AmiiboDetailsViewModel
            {
                Id = a.Id,
                Name = a.Name,
                Description = a.Description,
                ImgUrl = a.ImgUrl,
                AmiiboSeriesId = a.AmiiboSeriesId,
                ReleaseDate = a.ReleaseDate,
                AmiiboSeriesName = a.AmiiboSeries.Name,
                Franchise = a.Franchise,
            }).FirstOrDefault();

            var franchiseAmiibos = this.GetAllByFranchise(amiibo.Franchise);

            amiibo.FranchiseAmiibos = franchiseAmiibos;

            var prices = this.scrapeService.GetPrices(priceUrl);

            amiibo.UsedPrice = prices.UsedPrice;
            amiibo.CompletePrice = prices.CompletePrice;
            amiibo.NewPrice = prices.NewPrice;

            return amiibo;
        }

        public async Task<int> DeleteAmiiboAsync(int id)
        {
            var amiibo = this.amiiboRepository.All().Where(a => a.Id == id).FirstOrDefault();

            this.amiiboRepository.Delete(amiibo);

            await this.amiiboRepository.SaveChangesAsync();

            return amiibo.AmiiboSeriesId;
        }

        public async Task AddAmiiboToCollectionAsync(int amiiboId, string userId, decimal pricePaid, bool isItNewAndSealed)
        {
            if (this.collectionRepository.All().Where(a => a.AmiiboId == amiiboId && a.UserId == userId).Any())
            {
                var amiibo = this.collectionRepository.All().Where(a => a.AmiiboId == amiiboId && a.UserId == userId).FirstOrDefault();

                amiibo.IsInWishlist = false;

                this.collectionRepository.Update(amiibo);

                await this.collectionRepository.SaveChangesAsync();
            }
            else
            {
                this.amiiboRepository.All().Where(a => a.Id == amiiboId).FirstOrDefault().UserAmiibosCollection.Add(new UserAmiiboCollection
                {
                    AmiiboId = amiiboId,
                    UserId = userId,
                    PricePaid = pricePaid,
                    IsItNewAndSealed = isItNewAndSealed,
                    IsInWishlist = false,
                });

                await this.amiiboRepository.SaveChangesAsync();
            }
        }

        public async Task AddAmiiboToWishlistAsync(int amiiboId, string userId)
        {
            if (this.collectionRepository.All().Where(a => a.AmiiboId == amiiboId && a.UserId == userId).Any())
            {
                var amiibo = this.collectionRepository.All().Where(a => a.AmiiboId == amiiboId && a.UserId == userId).FirstOrDefault();

                amiibo.IsInWishlist = true;

                this.collectionRepository.Update(amiibo);

                await this.collectionRepository.SaveChangesAsync();
            }
            else
            {
                this.amiiboRepository.All().Where(a => a.Id == amiiboId).FirstOrDefault().UserAmiibosCollection.Add(new UserAmiiboCollection
                {
                    AmiiboId = amiiboId,
                    UserId = userId,
                    PricePaid = 0,
                    IsItNewAndSealed = false,
                    IsInWishlist = true,
                });

                await this.amiiboRepository.SaveChangesAsync();
            }
        }
    }
}
