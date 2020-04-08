namespace GameCollectorsHub.Web.ViewModels.Console
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class AddConsoleInputModel
    {
        [Required]
        [MinLength(3)]
        public string Name { get; set; }

        [Required]
        [MinLength(3)]
        public string ImgUrl { get; set; }

        [Required]
        public DateTime ReleaseDate { get; set; }

        [Required]
        [Range(1d, double.MaxValue)]
        public decimal InitialPrice { get; set; }

        [Required]
        [MinLength(3)]
        public string Description { get; set; }

        [Required]
        [MinLength(3)]
        public string Model { get; set; }

        [Required]
        [Display(Name = "Platform")]
        public int PlatformId { get; set; }
    }
}
