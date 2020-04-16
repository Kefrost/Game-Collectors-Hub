namespace GameCollectorsHub.Web.Controllers
{
    using System.Threading.Tasks;

    using GameCollectorsHub.Data.Models;
    using GameCollectorsHub.Services.Data;
    using GameCollectorsHub.Web.ViewModels.ConsoleCollection;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    public class ConsoleWishlistController : Controller
    {
        private readonly IConsoleCollectionService service;
        private readonly Microsoft.AspNetCore.Identity.UserManager<ApplicationUser> userManager;

        public ConsoleWishlistController(IConsoleCollectionService service, UserManager<ApplicationUser> userManager)
        {
            this.service = service;
            this.userManager = userManager;
        }

        public async Task<IActionResult> All()
        {
            var user = await this.userManager.GetUserAsync(this.User);

            var consoles = this.service.ListAllConsolesWishlist(user.Id);

            var viewModel = new AllConsoleCollectionViewModel { ConsoleCollectionItems = consoles };

            return this.View(viewModel);
        }

        public async Task<IActionResult> Delete(int consoleId)
        {
            var user = await this.userManager.GetUserAsync(this.User);

            var console = this.service.GetConsoleCollectionInputDetails(user.Id, consoleId);

            var viewModel = new AddConsoleToCollectionInputModel
            {
                ConsoleId = console.ConsoleId,
                ConsoleImgUrl = console.ConsoleImgUrl,
                ConsoleName = console.ConsoleName,
            };

            return this.View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteConfirm(int consoleId)
        {
            var user = await this.userManager.GetUserAsync(this.User);

            await this.service.DeleteConsoleInCollectionAsync(user.Id, consoleId);

            return this.RedirectToAction("All");
        }
    }
}
