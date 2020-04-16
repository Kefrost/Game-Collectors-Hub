namespace GameCollectorsHub.Web.ViewModels.Amiibo
{
    using System;

    public class AllAmiiboDetailsViewModel
    {
        public int Id { get; set; }

        public string ImgUrl { get; set; }

        public string Name { get; set; }

        public string SeriesName { get; set; }

        public string Franchise { get; set; }

        public DateTime ReleaseDate { get; set; }
    }
}
