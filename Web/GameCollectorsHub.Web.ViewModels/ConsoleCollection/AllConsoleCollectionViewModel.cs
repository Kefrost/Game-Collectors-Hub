namespace GameCollectorsHub.Web.ViewModels.ConsoleCollection
{
    using System.Collections.Generic;

    public class AllConsoleCollectionViewModel
    {
        public ICollection<ConsoleCollectionItemViewModel> ConsoleCollectionItems { get; set; }

        // public decimal CollectionValue { get; set; }
        public decimal TotalYouPaid { get; set; }

        public int ItemsInCollection => this.ConsoleCollectionItems.Count;
    }
}
