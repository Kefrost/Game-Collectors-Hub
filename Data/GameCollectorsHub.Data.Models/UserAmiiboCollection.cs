namespace GameCollectorsHub.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class UserAmiiboCollection
    {
        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        public int AmiiboId { get; set; }

        public virtual Amiibo Amiibo { get; set; }

        public decimal PricePaid { get; set; }

        public bool IsItNewAndSealed { get; set; }

        public bool IsInWishlist { get; set; }
    }
}
