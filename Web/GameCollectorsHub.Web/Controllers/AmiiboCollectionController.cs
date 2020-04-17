namespace GameCollectorsHub.Web.Controllers
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using GameCollectorsHub.Data.Models;
    using GameCollectorsHub.Services.Data;
    using GameCollectorsHub.Web.ViewModels.AmiiboCollection;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    public class AmiiboCollectionController : Controller
    {
        private readonly IAmiiboCollectionService service;
        private readonly UserManager<ApplicationUser> userManager;

        public AmiiboCollectionController(IAmiiboCollectionService service, UserManager<ApplicationUser> userManager)
        {
            this.service = service;
            this.userManager = userManager;
        }

        public async Task<IActionResult> AllCollection()
        {
            var user = await this.userManager.GetUserAsync(this.User);

            var amiibos = this.service.ListAllAmiibosCollection(user.Id);

            var viewModel = new AllAmiiboCollectionViewModel
            {
                AmiiboCollectionItems = amiibos,
                TotalYouPaid = amiibos.Sum(a => a.Cost),
            };

            viewModel.TotalYouPaid = Math.Round(viewModel.TotalYouPaid, 3);
            return this.View(viewModel);
        }

        public async Task<IActionResult> Details(int amiiboId)
        {
            var user = await this.userManager.GetUserAsync(this.User);

            var viewModel = this.service.GetAmiiboCollectionDetails(user.Id, amiiboId);

            return this.View(viewModel);
        }

        public async Task<IActionResult> Edit(int amiiboId)
        {
            var user = await this.userManager.GetUserAsync(this.User);

            var amiibo = this.service.GetAmiiboCollectionInputDetails(user.Id, amiiboId);

            var viewModel = new AddAmiiboToCollectionInputModel
            {
                AmiiboId = amiibo.AmiiboId,
                AmiiboImgUrl = amiibo.AmiiboImgUrl,
                AmiiboName = amiibo.AmiiboName,
                IsItNewAndSealed = amiibo.IsItNewAndSealed,
                PricePaid = amiibo.PricePaid,
            };

            return this.View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(AddAmiiboToCollectionInputModel model)
        {
            var user = await this.userManager.GetUserAsync(this.User);

            await this.service.EditAmiiboInCollection(model.AmiiboId, user.Id, model.PricePaid, model.IsItNewAndSealed);

            return this.RedirectToAction("Details", new { amiiboId = model.AmiiboId });
        }

        public async Task<IActionResult> Delete(int amiiboId)
        {
            var user = await this.userManager.GetUserAsync(this.User);

            var amiibo = this.service.GetAmiiboCollectionInputDetails(user.Id, amiiboId);

            var viewModel = new AddAmiiboToCollectionInputModel
            {
                AmiiboName = amiibo.AmiiboName,
                AmiiboImgUrl = amiibo.AmiiboImgUrl,
                AmiiboId = amiibo.AmiiboId,
                IsItNewAndSealed = amiibo.IsItNewAndSealed,
                PricePaid = amiibo.PricePaid,
            };

            return this.View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteConfirm(int amiiboId)
        {
            var user = await this.userManager.GetUserAsync(this.User);

            await this.service.DeleteAmiiboInCollectionAsync(user.Id, amiiboId);

            return this.RedirectToAction("AllCollection", new { userId = user.Id });
        }
    }
}
