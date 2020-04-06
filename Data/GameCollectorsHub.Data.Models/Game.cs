using System;
using System.Collections.Generic;
using System.Text;

namespace GameCollectorsHub.Data.Models
{
    public class Game
    {
        public Game()
        {
            this.Ratings = new HashSet<Rating>();
            this.Reviews = new HashSet<Review>();
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

        public virtual ICollection<Review> Reviews { get; set; }

        public virtual ICollection<Rating> Ratings { get; set; }
    }
}
