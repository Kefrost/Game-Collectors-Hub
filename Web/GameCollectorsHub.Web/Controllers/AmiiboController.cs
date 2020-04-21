namespace GameCollectorsHub.Web.Controllers
{
    using System.Threading.Tasks;

    using GameCollectorsHub.Data.Models;
    using GameCollectorsHub.Services.Data;
    using GameCollectorsHub.Web.ViewModels.Amiibo;
    using GameCollectorsHub.Web.ViewModels.AmiiboCollection;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    public class AmiiboController : Controller
    {
        private readonly IAmiiboService service;
        private readonly IAmiiboCollectionService collectionService;
        private readonly UserManager<ApplicationUser> userManager;

        public AmiiboController(IAmiiboService service, IAmiiboCollectionService collectionService, UserManager<ApplicationUser> userManager)
        {
            this.service = service;
            this.collectionService = collectionService;
            this.userManager = userManager;
        }

        public IActionResult Series()
        {
            var series = this.service.GetAmiiboSeries();

            var viewModel = new AmiiboSeriesViewModel { AmiiboSeries = series };

            return this.View(viewModel);
        }

        public IActionResult Details(int id)
        {
            var userId = this.userManager.GetUserId(this.User);

            var viewModel = this.service.GetAmiiboDetails(id);

            if (!string.IsNullOrEmpty(userId))
            {
                viewModel.IsInCollection = this.collectionService.IsAmiiboInCollection(userId, id);

                viewModel.IsInWishlist = this.collectionService.IsAmiiboInWishlist(userId, id);
            }

            return this.View(viewModel);
        }

        [Authorize(Roles = "Administrator")]
        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Create(AddAmiiboInputModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            var amiiboId = await this.service.CreateAmiiboAsync(model);

            return this.RedirectToAction("Details", new { id = amiiboId });
        }

        public IActionResult Browse(int id)
        {
            var amiibos = this.service.GetAllBySeries(id);

            var viewModel = new AllAmiibosViewModel { Amiibos = amiibos };

            return this.View(viewModel);
        }

        [Authorize(Roles = "Administrator")]
        public IActionResult Edit(int id)
        {
            var amiibo = this.service.GetAmiiboDetails(id);

            var viewModel = new AddAmiiboInputModel
            {
                Id = id,
                Name = amiibo.Name,
                Description = amiibo.Description,
                ImgUrl = amiibo.ImgUrl,
                ReleaseDate = amiibo.ReleaseDate,
                AmiiboSeriesId = amiibo.AmiiboSeriesId,
                Franchise = amiibo.Franchise,
            };

            return this.View(viewModel);
        }

        [HttpPost]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Edit(AddAmiiboInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(input);
            }

            await this.service.EditAmiiboAsync(input);

            return this.RedirectToAction("Details", new { id = input.Id });
        }

        [Authorize(Roles = "Administrator")]
        public IActionResult Delete(int id)
        {
            var amiibo = this.service.GetAmiiboDetails(id);

            var viewModel = new AddAmiiboInputModel
            {
                Id = id,
                Name = amiibo.Name,
                Description = amiibo.Description,
                Franchise = amiibo.Franchise,
                ImgUrl = amiibo.ImgUrl,
                ReleaseDate = amiibo.ReleaseDate,
                AmiiboSeriesId = amiibo.AmiiboSeriesId,
            };

            return this.View(viewModel);
        }

        [HttpPost]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> DeleteConfirm(int id)
        {
            var platformId = await this.service.DeleteAmiiboAsync(id);

            return this.RedirectToAction("Browse", new { id = platformId });
        }

        [Authorize]
        public IActionResult AddToCollection(int amiiboId)
        {
            var amiibo = this.service.GetAmiiboDetails(amiiboId);

            var viewModel = new AddAmiiboToCollectionInputModel { AmiiboId = amiiboId, AmiiboImgUrl = amiibo.ImgUrl, AmiiboName = amiibo.Name, };

            return this.View(viewModel);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> AddToCollection(AddAmiiboToCollectionInputModel model)
        {
            var user = await this.userManager.GetUserAsync(this.User);

            await this.service.AddAmiiboToCollectionAsync(model.AmiiboId, user.Id, model.PricePaid, model.IsItNewAndSealed);

            return this.RedirectToAction("Details", new { id = model.AmiiboId });
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> AddToWishlist(int amiiboId)
        {
            var user = await this.userManager.GetUserAsync(this.User);

            await this.service.AddAmiiboToWishlistAsync(amiiboId, user.Id);

            return this.Redirect("/AmiiboWishlist/All");
        }
    }
}
