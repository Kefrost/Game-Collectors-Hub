namespace GameCollectorsHub.Data.Models
{
    public class GamesReview
    {
        public int GameId { get; set; }

        public virtual Game Game { get; set; }

        public int ReviewId { get; set; }

        public virtual Review Review { get; set; }
    }
}
