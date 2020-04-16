namespace GameCollectorsHub.Web.Controllers
{
    using System.Threading.Tasks;

    using GameCollectorsHub.Data.Models;
    using GameCollectorsHub.Services.Data;
    using GameCollectorsHub.Web.ViewModels.GameCollection;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    public class GameWishlistController : Controller
    {
        private readonly IGameCollectionService service;
        private readonly Microsoft.AspNetCore.Identity.UserManager<ApplicationUser> userManager;

        public GameWishlistController(IGameCollectionService service, UserManager<ApplicationUser> userManager)
        {
            this.service = service;
            this.userManager = userManager;
        }

        public async Task<IActionResult> All()
        {
            var user = await this.userManager.GetUserAsync(this.User);

            var games = this.service.ListAllGameWishlist(user.Id);

            var viewModel = new AllGameCollectionViewModel { GameCollectionItems = games };

            return this.View(viewModel);
        }

        public async Task<IActionResult> Delete(int gameId)
        {
            var user = await this.userManager.GetUserAsync(this.User);

            var game = this.service.GetGameCollectionInputDetails(user.Id, gameId);

            var viewModel = new AddGameToCollectionInputModel
            {
                GameId = game.GameId,
                UserId = user.Id,
                GameImgUrl = game.GameImgUrl,
                GameName = game.GameName,
            };

            return this.View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteConfirm(int gameId)
        {
            var user = await this.userManager.GetUserAsync(this.User);

            await this.service.DeleteGameInCollectionAsync(user.Id, gameId);

            return this.RedirectToAction("All");
        }
    }
}
