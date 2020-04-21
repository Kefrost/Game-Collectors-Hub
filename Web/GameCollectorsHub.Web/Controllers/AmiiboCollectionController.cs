namespace GameCollectorsHub.Web.Controllers
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using GameCollectorsHub.Data.Models;
    using GameCollectorsHub.Services.Data;
    using GameCollectorsHub.Web.ViewModels.AmiiboCollection;
    using Microsoft.AspNetCore.Authorization;
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

        [Authorize]
        public IActionResult AllCollection()
        {
            var userId = this.userManager.GetUserId(this.User);

            var amiibos = this.service.ListAllAmiibosCollection(userId);

            var value = 0.0m;

            foreach (var amiibo in amiibos)
            {
                var resValue = 0.0m;
                var parse = decimal.TryParse(amiibo.Value.Replace("\n", string.Empty).Replace('$', ' ').Trim(), out resValue);
                value += resValue;
            }

            var viewModel = new AllAmiiboCollectionViewModel
            {
                AmiiboCollectionItems = amiibos,
                TotalYouPaid = amiibos.Sum(a => a.Cost),
                CollectionValue = value,
            };

            viewModel.TotalYouPaid = Math.Round(viewModel.TotalYouPaid, 3);
            return this.View(viewModel);
        }

        [Authorize]
        public IActionResult Details(int amiiboId)
        {
            var userId = this.userManager.GetUserId(this.User);

            var viewModel = this.service.GetAmiiboCollectionDetails(userId, amiiboId);

            return this.View(viewModel);
        }

        [Authorize]
        public IActionResult Edit(int amiiboId)
        {
            var userId = this.userManager.GetUserId(this.User);

            var amiibo = this.service.GetAmiiboCollectionInputDetails(userId, amiiboId);

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
        [Authorize]
        public async Task<IActionResult> Edit(AddAmiiboToCollectionInputModel model)
        {
            var user = await this.userManager.GetUserAsync(this.User);

            await this.service.EditAmiiboInCollection(model.AmiiboId, user.Id, model.PricePaid, model.IsItNewAndSealed);

            return this.RedirectToAction("Details", new { amiiboId = model.AmiiboId });
        }

        [Authorize]
        public IActionResult Delete(int amiiboId)
        {
            var userId = this.userManager.GetUserId(this.User);

            var amiibo = this.service.GetAmiiboCollectionInputDetails(userId, amiiboId);

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
        [Authorize]
        public async Task<IActionResult> DeleteConfirm(int amiiboId)
        {
            var user = await this.userManager.GetUserAsync(this.User);

            await this.service.DeleteAmiiboInCollectionAsync(user.Id, amiiboId);

            return this.RedirectToAction("AllCollection", new { userId = user.Id });
        }
    }
}
