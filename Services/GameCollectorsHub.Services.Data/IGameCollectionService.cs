using GameCollectorsHub.Web.ViewModels.GameCollection;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameCollectorsHub.Services.Data
{
    public interface IGameCollectionService
    {
        public ICollection<GameCollectionItemViewModel> ListAllGameCollection(string userId);
    }
}
