// ReSharper disable VirtualMemberCallInConstructor
namespace GameCollectorsHub.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using GameCollectorsHub.Data.Common.Models;

    public class Rating : BaseDeletableModel<int>
    {
        public int GameId { get; set; }

        public virtual Game Game { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        [Range(1, 10)]
        public int RatingScore { get; set; }

        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }
    }
}
