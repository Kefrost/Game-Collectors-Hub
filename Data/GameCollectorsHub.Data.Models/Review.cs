namespace GameCollectorsHub.Data.Models
{
    using System.Collections.Generic;

    using GameCollectorsHub.Data.Common.Models;

    public class Review : BaseDeletableModel<int>
    {
        public Review()
        {
            this.Comments = new HashSet<Comment>();
            this.GamesReviews = new HashSet<GamesReview>();
        }

        public string Title { get; set; }

        public string Content { get; set; }

        public int RatingScore { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }

        public virtual ICollection<GamesReview> GamesReviews { get; set; }
    }
}
