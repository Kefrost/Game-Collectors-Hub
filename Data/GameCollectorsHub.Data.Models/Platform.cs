namespace GameCollectorsHub.Data.Models
{
    using System.Collections.Generic;

    public class Platform
    {
        public Platform()
        {
            this.Games = new HashSet<Game>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string ImageUrl { get; set; }

        public virtual IEnumerable<Game> Games { get; set; }
    }
}