namespace GameCollectorsHub.Web.ViewModels.GameCollection
{
    using System.ComponentModel.DataAnnotations;

    public class AddGameToCollectionInputModel
    {
        public string UserId { get; set; }

        public int GameId { get; set; }

        public string GameImgUrl { get; set; }

        public string GameName { get; set; }

        [Display(Name = "Price You Paid")]
        public decimal PricePaid { get; set; }

        [Display(Name = "Box")]
        public bool BoxIncluded { get; set; }

        [Display(Name = "Manual")]
        public bool ManualIncluded { get; set; }

        [Display(Name = "Is it New and Sealed ?")]
        public bool IsItNewAndSealed { get; set; }
    }
}
