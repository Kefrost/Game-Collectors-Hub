namespace GameCollectorsHub.Data.Models
{
    using System;

    public class GameConsole
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string ImgUrl { get; set; }

        public DateTime ReleaseDate { get; set; }

        public decimal InitialPrice { get; set; }

        public string Description { get; set; }

        public string Model { get; set; }

        public int PlatformId { get; set; }

        public virtual Platform Platform { get; set; }
    }
}
