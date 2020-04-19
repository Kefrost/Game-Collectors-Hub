namespace GameCollectorsHub.Web.ViewModels.GameReview
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using GameCollectorsHub.Data.Models;

    public class GameReviewDetailsViewModel
    {
        public int Id { get; set; }

        public int GameId { get; set; }

        public string GameName { get; set; }

        public string GameImg { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public int RatingScore { get; set; }

        public IEnumerable<ReviewCommentViewModel> Comments { get; set; }

        public string AddCommentContent { get; set; }
    }
}
