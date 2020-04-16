namespace GameCollectorsHub.Web.ViewModels.GameCollection
{
    using System.Collections.Generic;

    public class AllGameCollectionViewModel
    {
        public string UserId { get; set; }

        public ICollection<GameCollectionItemViewModel> GameCollectionItems { get; set; }

        public decimal CollectionValue { get; set; }

        public decimal TotalYouPaid { get; set; }

        public int ItemsInCollection => this.GameCollectionItems.Count;
    }
}
