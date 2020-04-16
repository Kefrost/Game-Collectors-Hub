namespace GameCollectorsHub.Web.ViewModels.AmiiboCollection
{
    using System.Collections.Generic;

    public class AllAmiiboCollectionViewModel
    {
        public ICollection<AmiiboCollectionItemViewModel> AmiiboCollectionItems { get; set; }

        public decimal CollectionValue { get; set; }

        public decimal TotalYouPaid { get; set; }

        public int ItemsInCollection => this.AmiiboCollectionItems.Count;
    }
}
