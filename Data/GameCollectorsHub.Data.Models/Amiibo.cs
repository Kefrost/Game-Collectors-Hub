namespace GameCollectorsHub.Data.Models
{
    using System;

    public class Amiibo
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string ImgUrl { get; set; }

        public string Franchise { get; set; }

        public DateTime ReleaseDate { get; set; }

        public string Description { get; set; }

        public int AmiiboSeriesId { get; set; }

        public virtual AmiiboSeries AmiiboSeries { get; set; }
    }
}
