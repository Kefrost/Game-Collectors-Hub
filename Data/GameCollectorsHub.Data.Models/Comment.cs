// ReSharper disable VirtualMemberCallInConstructor
namespace GameCollectorsHub.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using GameCollectorsHub.Data.Common.Models;

    public class Comment : BaseDeletableModel<int>
    {
        public int ReviewId { get; set; }

        public virtual Review Review { get; set; }

        [Required]
        public string Content { get; set; }

        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }
    }
}
