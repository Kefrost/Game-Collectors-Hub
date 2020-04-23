using System;

namespace GameCollectorsHub.Web.ViewModels.GameReview
{
    public class ReviewCommentViewModel
    {
        public int Id { get; set; }

        public string UserId { get; set; }

        public string UserName { get; set; }

        public string Content { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}
