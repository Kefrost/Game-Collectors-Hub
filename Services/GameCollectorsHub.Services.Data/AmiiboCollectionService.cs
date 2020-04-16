namespace GameCollectorsHub.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using GameCollectorsHub.Data.Common.Repositories;
    using GameCollectorsHub.Data.Models;
    using GameCollectorsHub.Web.ViewModels.AmiiboCollection;

    public class AmiiboCollectionService : IAmiiboCollectionService
    {
        private readonly IRepository<UserAmiiboCollection> repository;

        public AmiiboCollectionService(IRepository<UserAmiiboCollection> repository)
        {
            this.repository = repository;
        }

        public ICollection<AmiiboCollectionItemViewModel> ListAllAmiibosCollection(string userId)
        {
            var amiibos = this.repository.All().Where(a => a.UserId == userId && a.IsInWishlist == false).Select(a => new AmiiboCollectionItemViewModel
            {
                AmiiboId = a.AmiiboId,
                AmiiboImgUrl = a.Amiibo.ImgUrl,
                AmiiboName = a.Amiibo.Name,
                AmiiboSeries = a.Amiibo.AmiiboSeries.Name,
                Value = a.PricePaid,
                Cost = a.PricePaid,

                // TODO
            }).OrderBy(a => a.AmiiboName).ToList();

            return amiibos;
        }

        public ICollection<AmiiboCollectionItemViewModel> ListAllAmiibosWishlist(string userId)
        {
            var amiibos = this.repository.All().Where(a => a.UserId == userId && a.IsInWishlist == true).Select(a => new AmiiboCollectionItemViewModel
            {
                AmiiboId = a.AmiiboId,
                AmiiboName = a.Amiibo.Name,
                AmiiboSeries = a.Amiibo.AmiiboSeries.Name,
                AmiiboImgUrl = a.Amiibo.ImgUrl,
                Value = a.PricePaid,
                Cost = a.PricePaid,

                // TODO
            }).OrderBy(a => a.AmiiboName).ToList();

            return amiibos;
        }

        public AmiiboCollectionDetailsViewModel GetAmiiboCollectionDetails(string userId, int amiiboId)
        {
            var amiibo = this.repository.All().Where(a => a.AmiiboId == amiiboId && a.UserId == userId).FirstOrDefault();

            var amiiboReturn = this.repository.All().Where(a => a.AmiiboId == amiiboId && a.UserId == userId).Select(a => new AmiiboCollectionDetailsViewModel
            {
                AmiiboId = a.AmiiboId,
                AmiiboName = a.Amiibo.Name,
                AmiiboImgUrl = a.Amiibo.ImgUrl,
                AmiiboSeries = a.Amiibo.AmiiboSeries.Name,
                Value = a.PricePaid,
                Condition = a.IsItNewAndSealed ? "New and Sealed" : "Normal wear",
                Cost = a.PricePaid,

                // TODO
            }).FirstOrDefault();

            return amiiboReturn;
        }

        public async Task EditAmiiboInCollection(int amiiboId, string userId, decimal pricePaid, bool isItNewAndSealed)
        {
            var amiibo = this.repository.All().Where(a => a.UserId == userId && a.AmiiboId == amiiboId).FirstOrDefault();

            amiibo.PricePaid = pricePaid;
            amiibo.IsItNewAndSealed = isItNewAndSealed;
            amiibo.IsInWishlist = false;

            this.repository.Update(amiibo);

            await this.repository.SaveChangesAsync();
        }

        public AddAmiiboToCollectionInputModel GetAmiiboCollectionInputDetails(string userId, int amiiboId)
        {
            var amiiboReturn = this.repository.All().Where(a => a.AmiiboId == amiiboId && a.UserId == userId).Select(a => new AddAmiiboToCollectionInputModel
            {
                AmiiboId = a.AmiiboId,
                AmiiboImgUrl = a.Amiibo.ImgUrl,
                AmiiboName = a.Amiibo.Name,
                IsItNewAndSealed = a.IsItNewAndSealed,
                PricePaid = a.PricePaid,
            }).FirstOrDefault();

            return amiiboReturn;
        }

        public async Task DeleteAmiiboInCollectionAsync(string userId, int amiiboId)
        {
            var amiibo = this.repository.All().Where(a => a.UserId == userId && a.AmiiboId == amiiboId).FirstOrDefault();

            this.repository.Delete(amiibo);

            await this.repository.SaveChangesAsync();
        }
    }
}
