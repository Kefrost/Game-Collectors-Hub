namespace GameCollectorsHub.Web.ViewModels.Game
{
    using System;

    public class ListGameDetailsViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string ImgUrl { get; set; }

        public string PlatformName { get; set; }

        public string Publisher { get; set; }

        public string Developer { get; set; }

        public DateTime ReleaseDate { get; set; }
    }
}
