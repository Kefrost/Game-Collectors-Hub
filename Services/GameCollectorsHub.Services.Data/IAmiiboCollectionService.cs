namespace GameCollectorsHub.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    using GameCollectorsHub.Web.ViewModels.AmiiboCollection;

    public interface IAmiiboCollectionService
    {
        public ICollection<AmiiboCollectionItemViewModel> ListAllAmiibosCollection(string userId);

        public ICollection<AmiiboCollectionItemViewModel> ListAllAmiibosWishlist(string userId);

        public AmiiboCollectionDetailsViewModel GetAmiiboCollectionDetails(string userId, int amiiboId);

        public Task EditAmiiboInCollection(int amiiboId, string userId, decimal pricePaid, bool isItNewAndSealed);

        public AddAmiiboToCollectionInputModel GetAmiiboCollectionInputDetails(string userId, int amiiboId);

        public Task DeleteAmiiboInCollectionAsync(string userId, int amiiboId);

        public bool IsAmiiboInCollection(string userId, int amiiboId);
    }
}
