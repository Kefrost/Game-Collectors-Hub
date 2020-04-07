// ReSharper disable VirtualMemberCallInConstructor
namespace GameCollectorsHub.Data.Models
{
    using GameCollectorsHub.Data.Common.Models;

    public class Rating : BaseDeletableModel<int>
    {
        public int GameId { get; set; }

        public virtual Game Game { get; set; }

        public string Content { get; set; }

        public int RatingScore { get; set; }

        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }
    }
}
