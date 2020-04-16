namespace GameCollectorsHub.Web.Controllers
{
    using System.Threading.Tasks;

    using GameCollectorsHub.Data.Models;
    using GameCollectorsHub.Services.Data;
    using GameCollectorsHub.Web.ViewModels.AmiiboCollection;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    public class AmiiboWishlistController : Controller
    {
        private readonly IAmiiboCollectionService service;
        private readonly UserManager<ApplicationUser> userManager;

        public AmiiboWishlistController(IAmiiboCollectionService service, UserManager<ApplicationUser> userManager)
        {
            this.service = service;
            this.userManager = userManager;
        }

        public async Task<IActionResult> All()
        {
            var user = await this.userManager.GetUserAsync(this.User);

            var amiibos = this.service.ListAllAmiibosWishlist(user.Id);

            var viewModel = new AllAmiiboCollectionViewModel { AmiiboCollectionItems = amiibos };

            return this.View(viewModel);
        }

        public async Task<IActionResult> Delete(int amiiboId)
        {
            var user = await this.userManager.GetUserAsync(this.User);

            var amiibo = this.service.GetAmiiboCollectionInputDetails(user.Id, amiiboId);

            var viewModel = new AddAmiiboToCollectionInputModel
            {
                AmiiboId = amiibo.AmiiboId,
                AmiiboImgUrl = amiibo.AmiiboImgUrl,
                AmiiboName = amiibo.AmiiboName,
            };

            return this.View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteConfirm(int amiiboId)
        {
            var user = await this.userManager.GetUserAsync(this.User);

            await this.service.DeleteAmiiboInCollectionAsync(user.Id, amiiboId);

            return this.RedirectToAction("All");
        }
    }
}
