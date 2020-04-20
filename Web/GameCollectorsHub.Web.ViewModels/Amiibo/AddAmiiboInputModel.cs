namespace GameCollectorsHub.Web.ViewModels.Amiibo
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class AddAmiiboInputModel
    {
        public int Id { get; set; }

        [Required]
        [MinLength(3)]
        public string Name { get; set; }

        [Required]
        public string ImgUrl { get; set; }

        public string PriceUrl { get; set; }

        [Required]
        [MinLength(3)]
        public string Franchise { get; set; }

        [Required]
        public DateTime ReleaseDate { get; set; }

        [Required]
        [MinLength(3)]
        public string Description { get; set; }

        [Required]
        [Display(Name = "AmiiboSeries")]
        public int AmiiboSeriesId { get; set; }
    }
}
