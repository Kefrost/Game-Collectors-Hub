namespace GameCollectorsHub.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Platform
    {
        public Platform()
        {
            this.Games = new HashSet<Game>();

            this.GameConsoles = new HashSet<GameConsole>();
        }

        public int Id { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        public virtual ICollection<Game> Games { get; set; }

        public virtual ICollection<GameConsole> GameConsoles { get; set; }
    }
}
