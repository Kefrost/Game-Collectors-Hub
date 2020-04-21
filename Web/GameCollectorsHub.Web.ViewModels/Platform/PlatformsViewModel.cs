namespace GameCollectorsHub.Web.ViewModels.Platform
{
    using System.Collections.Generic;

    public class PlatformsViewModel
    {
        public IEnumerable<PlatformDetailsViewModel> Platforms { get; set; }

        public string SearchString { get; set; }
    }
}
