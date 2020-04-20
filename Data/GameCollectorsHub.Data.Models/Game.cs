namespace GameCollectorsHub.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Game
    {
        public Game()
        {
            this.Ratings = new HashSet<Rating>();
            this.Reviews = new HashSet<Review>();
            this.UserGamesCollection = new HashSet<UserGameCollection>();
        }

        public int Id { get; set; }

        [Required]
        [MinLength(3)]
        public string Name { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        public string PriceUrl { get; set; }

        [Required]
        public DateTime ReleaseDate { get; set; }

        [Required]
        public string Genre { get; set; }

        public string Series { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string Publisher { get; set; }

        [Required]
        public string Developer { get; set; }

        public int PlatformId { get; set; }

        [Required]
        public bool IsLaunchTitle { get; set; }

        public virtual Platform Platform { get; set; }

        public virtual ICollection<Review> Reviews { get; set; }

        public virtual ICollection<Rating> Ratings { get; set; }

        public virtual ICollection<UserGameCollection> UserGamesCollection { get; set; }
    }
}
