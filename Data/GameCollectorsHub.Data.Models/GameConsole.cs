namespace GameCollectorsHub.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class GameConsole
    {
        public GameConsole()
        {
            this.UserConsolesCollection = new HashSet<UserConsoleCollection>();
        }

        public int Id { get; set; }

        [Required]
        [MinLength(3)]
        public string Name { get; set; }

        [Required]
        public string ImgUrl { get; set; }

        [Required]
        public DateTime ReleaseDate { get; set; }

        [Required]
        public decimal InitialPrice { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public int GamesReleased { get; set; }

        [Required]
        public string Model { get; set; }

        public int PlatformId { get; set; }

        public virtual Platform Platform { get; set; }

        public virtual ICollection<UserConsoleCollection> UserConsolesCollection { get; set; }
    }
}
