namespace GameCollectorsHub.Web.ViewModels.Console
{
    using System;
    using System.Collections.Generic;

    public class ConsoleDetailsViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string ImgUrl { get; set; }

        public DateTime ReleaseDate { get; set; }

        public decimal InitialPrice { get; set; }

        public int GamesReleased { get; set; }

        public string Description { get; set; }

        public string Model { get; set; }

        public bool IsInCollection { get; set; }

        public int PlatformId { get; set; }

        public IEnumerable<ConsoleLaunchTitlesViewModel> LauchTitles { get; set; }
    }
}
