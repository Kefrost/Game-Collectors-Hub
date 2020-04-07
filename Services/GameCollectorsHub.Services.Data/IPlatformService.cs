namespace GameCollectorsHub.Services.Data
{
    using System.Collections.Generic;

    using GameCollectorsHub.Web.ViewModels.Platform;

    public interface IPlatformService
    {
        public IEnumerable<PlatformDetailsViewModel> GetPlatforms();
    }
}
