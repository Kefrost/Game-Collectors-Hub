namespace GameCollectorsHub.Web.ViewModels.Console
{
using System;

public class ListConsoleDetailsViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string ImgUrl { get; set; }

        public string PlatformName { get; set; }

        public string Model { get; set; }

        public DateTime ReleaseDate { get; set; }
    }
}
