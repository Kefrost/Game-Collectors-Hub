namespace GameCollectorsHub.Web.ViewModels.GameCollection
{
    public class GameCollectionDetailsViewModel
    {
        public string UserId { get; set; }

        public int GameId { get; set; }

        public string GameName { get; set; }

        public string GameImgUrl { get; set; }

        public string PlatformName { get; set; }

        public decimal Value { get; set; }

        public decimal Cost { get; set; }

        public string WhatIncludes { get; set; }

        public string Condition { get; set; }
    }
}
