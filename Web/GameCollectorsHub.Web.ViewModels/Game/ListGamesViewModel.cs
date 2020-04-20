namespace GameCollectorsHub.Web.ViewModels.Game
{
    using System.Collections.Generic;

    public class ListGamesViewModel
    {
        public IEnumerable<ListGameDetailsViewModel> Games { get; set; }

        public int PagesCount { get; set; }
    }
}
