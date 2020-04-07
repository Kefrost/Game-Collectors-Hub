namespace GameCollectorsHub.Services.Data
{
    using System.Collections.Generic;

    using GameCollectorsHub.Web.ViewModels.Home;

    public interface IHomeService
    {
        public HomeViewModel GetAll();
    }
}
