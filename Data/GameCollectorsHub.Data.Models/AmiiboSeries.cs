namespace GameCollectorsHub.Data.Models
{
    using System.Collections.Generic;

    public class AmiiboSeries
    {
        public AmiiboSeries()
        {
            this.Amiibos = new HashSet<Amiibo>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string ImgUrl { get; set; }

        public virtual ICollection<Amiibo> Amiibos { get; set; }
    }
}
