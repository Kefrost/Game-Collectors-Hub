namespace GameCollectorsHub.Data.Models
{
    using System.Collections.Generic;

    using GameCollectorsHub.Data.Common.Models;

    public class Review : BaseDeletableModel<int>
    {
        public Review()
        {
            this.Comments = new HashSet<Comment>();
        }

        public string Title { get; set; }

        public string Content { get; set; }

        public int RatingScore { get; set; }

        public ICollection<Comment> Comments { get; set; }
    }
}
