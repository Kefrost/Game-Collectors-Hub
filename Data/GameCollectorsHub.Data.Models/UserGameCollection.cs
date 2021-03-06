﻿namespace GameCollectorsHub.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class UserGameCollection
    {
        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        public int GameId { get; set; }

        public virtual Game Game { get; set; }

        public decimal PricePaid { get; set; }

        public bool BoxIncluded { get; set; }

        public bool ManualIncluded { get; set; }

        public bool IsItNewAndSealed { get; set; }

        public bool IsInWishlist { get; set; }
    }
}
