namespace GameCollectorsHub.Web.ViewModels.Game
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class AddGameInputModel
    {
        public int Id { get; set; }

        [Required]
        [MinLength(3)]
        public string Name { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        [Required]
        public DateTime ReleaseDate { get; set; }

        [Required]
        [MinLength(3)]
        public string Genre { get; set; }

        [Required]
        [MinLength(3)]
        public string Series { get; set; }

        [Required]
        [MinLength(3)]
        public string Description { get; set; }

        [Required]
        [MinLength(3)]
        public string Publisher { get; set; }

        [Required]
        [MinLength(3)]
        public string Developer { get; set; }

        [Required]
        [Display(Name = "Platform")]
        public int PlatformId { get; set; }

        [Required]
        [Display(Name = "Launch Title ?")]
        public bool IsLaunchTitle { get; set; }
    }
}
