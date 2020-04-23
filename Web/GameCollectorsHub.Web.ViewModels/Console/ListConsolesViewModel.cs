namespace GameCollectorsHub.Web.ViewModels.Console
{
    using System.Collections.Generic;

    public class ListConsolesViewModel
    {
        public IEnumerable<ListConsoleDetailsViewModel> Consoles { get; set; }

        public int PagesCount { get; set; }

        public string DisplayName { get; set; }

    }
}
