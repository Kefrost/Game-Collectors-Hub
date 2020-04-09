namespace GameCollectorsHub.Data.Models
{
    using System;
    using System.Collections.Generic;

    public class Game
    {
        public Game()
        {
            this.Ratings = new HashSet<Rating>();
            this.GamesReviews = new HashSet<GamesReview>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string ImageUrl { get; set; }

        public DateTime ReleaseDate { get; set; }

        public string Genre { get; set; }

        public string Series { get; set; }

        public string Description { get; set; }

        public string Publisher { get; set; }

        public string Developer { get; set; }

        public int PlatformId { get; set; }

        public virtual Platform Platform { get; set; }

        public virtual ICollection<GamesReview> GamesReviews { get; set; }

        public virtual ICollection<Rating> Ratings { get; set; }
    }
}
