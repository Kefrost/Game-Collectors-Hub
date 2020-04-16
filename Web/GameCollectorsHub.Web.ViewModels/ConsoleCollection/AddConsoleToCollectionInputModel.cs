namespace GameCollectorsHub.Web.ViewModels.ConsoleCollection
{
    using System.ComponentModel.DataAnnotations;

    public class AddConsoleToCollectionInputModel
    {
        public int ConsoleId { get; set; }

        public string ConsoleImgUrl { get; set; }

        public string ConsoleName { get; set; }

        [Display(Name = "Price You Paid")]
        public decimal PricePaid { get; set; }

        [Display(Name = "Box")]
        public bool BoxIncluded { get; set; }

        [Display(Name = "Is it New and Sealed ?")]
        public bool IsItNewAndSealed { get; set; }
    }
}
