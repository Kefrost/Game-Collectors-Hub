using System;
using System.Collections.Generic;
using System.Text;

namespace GameCollectorsHub.Web.ViewModels.Game
{
    public class GameUserRatingViewModel
    {
        public string UserId { get; set; }

        public string UserName { get; set; }

        public string Content { get; set; }

        public int RatingScore { get; set; }
    }
}
