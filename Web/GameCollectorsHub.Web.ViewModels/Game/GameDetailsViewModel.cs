namespace GameCollectorsHub.Web.ViewModels.Game
{
    using System;
    using System.Collections.Generic;

    public class GameDetailsViewModel
    {
        public int Id { get; set; }

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

        public bool IsInCollection { get; set; }

        public bool IsInWishlist { get; set; }

        public IEnumerable<GameDetailsReviewViewModel> Reviews { get; set; }
    }
}
