namespace GameCollectorsHub.Web.ViewModels.Game
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class GameDetailsViewModel
    {
        public int Id { get; set; }

        public string UserId { get; set; }

        public string Name { get; set; }

        public string ImageUrl { get; set; }

        public DateTime ReleaseDate { get; set; }

        public string Genre { get; set; }

        public string Series { get; set; }

        public string Description { get; set; }

        public string Publisher { get; set; }

        public string Developer { get; set; }

        public int PlatformId { get; set; }

        public string PlatformName { get; set; }

        public string OurReviewScore { get; set; }

        public string UserRatingScore { get; set; }

        public bool IsInCollection { get; set; }

        public bool IsInWishlist { get; set; }

        public IEnumerable<GameDetailsReviewViewModel> Reviews { get; set; }

        public IEnumerable<GameUserRatingViewModel> UserRatings { get; set; }

        [Required]
        [Range(1, 10)]
        public int AddUserRatingScore { get; set; }

        [Required]
        [MinLength(10)]
        [MaxLength(300)]
        public string AddUserRatingContent { get; set; }

        public string UsedPrice { get; set; }

        public string CompletePrice { get; set; }

        public string NewPrice { get; set; }

        public bool IsLaunchTitle { get; set; }

    }
}
