using GameCollectorsHub.Data.Common.Models;
using System.Collections.Generic;

namespace GameCollectorsHub.Data.Models
{
    public class Review : BaseDeletableModel<int>
    {
        public Review()
        {
            this.Comments = new HashSet<Comment>();
        }

        public string Title { get; set; }

        public string Content { get; set; }

        public int RatingScore { get; set; }

        public IEnumerable<Comment> Comments { get; set; }
    }
}