namespace GameCollectorsHub.Web.ViewModels.AmiiboCollection
{
    using System.ComponentModel.DataAnnotations;

    public class AddAmiiboToCollectionInputModel
    {
        public int AmiiboId { get; set; }

        public string AmiiboImgUrl { get; set; }

        public string AmiiboName { get; set; }

        [Display(Name = "Price You Paid")]
        public decimal PricePaid { get; set; }

        [Display(Name = "Is it New and Sealed ?")]
        public bool IsItNewAndSealed { get; set; }
    }
}
