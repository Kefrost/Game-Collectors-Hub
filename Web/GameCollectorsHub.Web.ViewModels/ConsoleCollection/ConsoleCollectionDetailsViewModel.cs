namespace GameCollectorsHub.Web.ViewModels.ConsoleCollection
{
    public class ConsoleCollectionDetailsViewModel
    {
        public int ConsoleId { get; set; }

        public string ConsoleName { get; set; }

        public string ConsoleImgUrl { get; set; }

        public string Model { get; set; }

        // public decimal Value { get; set; }
        public decimal Cost { get; set; }

        public string WhatIncludes { get; set; }

        public string Condition { get; set; }
    }
}
