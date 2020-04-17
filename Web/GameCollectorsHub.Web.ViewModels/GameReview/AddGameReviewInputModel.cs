namespace GameCollectorsHub.Web.ViewModels.GameReview
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class AddGameReviewInputModel
    {
        public int Id { get; set; }

        public int GameId { get; set; }

        public string GameName { get; set; }

        public string GameImg { get; set; }

        [Required]
        [MinLength(5)]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        [Range(1, 10)]
        public int RatingScore { get; set; }
    }
}
