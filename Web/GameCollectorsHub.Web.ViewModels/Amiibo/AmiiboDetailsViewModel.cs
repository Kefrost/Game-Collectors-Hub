namespace GameCollectorsHub.Web.ViewModels.Amiibo
{
    using System;
    using System.Collections.Generic;

    public class AmiiboDetailsViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string ImgUrl { get; set; }

        public string Franchise { get; set; }

        public DateTime ReleaseDate { get; set; }

        public string Description { get; set; }

        public int AmiiboSeriesId { get; set; }

        public string AmiiboSeriesName { get; set; }

        public bool IsInCollection { get; set; }

        public virtual IEnumerable<AllAmiiboDetailsViewModel> FranchiseAmiibos { get; set; }
    }
}
