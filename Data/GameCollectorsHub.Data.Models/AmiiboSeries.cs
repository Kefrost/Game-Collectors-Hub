namespace GameCollectorsHub.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class AmiiboSeries
    {
        public AmiiboSeries()
        {
            this.Amiibos = new HashSet<Amiibo>();
        }

        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        public string ImgUrl { get; set; }

        public virtual ICollection<Amiibo> Amiibos { get; set; }
    }
}
