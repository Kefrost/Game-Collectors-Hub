namespace GameCollectorsHub.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Amiibo
    {
        public int Id { get; set; }

        [MaxLength(50)]
        [MinLength(3)]
        [Required]
        public string Name { get; set; }

        [Required]
        public string ImgUrl { get; set; }

        [Required]
        public string Franchise { get; set; }

        [Required]
        public DateTime ReleaseDate { get; set; }

        [Required]
        public string Description { get; set; }

        public int AmiiboSeriesId { get; set; }

        public virtual AmiiboSeries AmiiboSeries { get; set; }
    }
}
