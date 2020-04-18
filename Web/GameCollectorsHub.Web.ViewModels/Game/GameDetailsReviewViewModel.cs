using System.Net;
using System.Text.RegularExpressions;

namespace GameCollectorsHub.Web.ViewModels.Game
{
    public class GameDetailsReviewViewModel
    {
        public int? ReviewId { get; set; }

        public string ReviewName { get; set; }

        public string ReviewImgUrl { get; set; }

        public string ReviewContent { get; set; }

        public string ShortReviewContent
        {
            get
            {
                var content = WebUtility.HtmlDecode(Regex.Replace(this.ReviewContent, @"<[^>]+>", string.Empty));
                return content.Length > 300
                    ? content.Substring(0, 300)
                    : content;
            }
        }

        public string OurReviewScore { get; set; }
    }
}
