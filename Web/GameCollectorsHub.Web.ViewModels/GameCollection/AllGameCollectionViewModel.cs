using System;
using System.Collections.Generic;
using System.Text;

namespace GameCollectorsHub.Web.ViewModels.GameCollection
{
    public class AllGameCollectionViewModel
    {
        public string UserId { get; set; }

        public ICollection<GameCollectionItemViewModel> GameCollectionItems { get; set; }

        public decimal CollectionValue { get; set; }

        public decimal TotalYouPaid { get; set; }

        public int ItemsInCollection => this.GameCollectionItems.Count;
    }
}
