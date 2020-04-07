namespace GameCollectorsHub.Data.Models
{
    using System.Collections.Generic;

    public class Platform
    {
        public Platform()
        {
            this.Games = new HashSet<Game>();

            this.GameConsoles = new HashSet<GameConsole>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string ImageUrl { get; set; }

        public virtual ICollection<Game> Games { get; set; }

        public virtual ICollection<GameConsole> GameConsoles { get; set; }
    }
}
