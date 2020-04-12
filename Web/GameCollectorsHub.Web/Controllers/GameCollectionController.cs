namespace GameCollectorsHub.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using GameCollectorsHub.Data.Models;
    using GameCollectorsHub.Services.Data;
    using GameCollectorsHub.Web.ViewModels.GameCollection;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    public class GameCollectionController : Controller
    {
        private readonly IGameCollectionService service;
        private readonly UserManager<ApplicationUser> userManager;

        public GameCollectionController(IGameCollectionService service, UserManager<ApplicationUser> userManager)
        {
            this.service = service;
            this.userManager = userManager;
        }

        public IActionResult AllCollection(string userId)
        {
            var games = this.service.ListAllGameCollection(userId);

            var viewModel = new AllGameCollectionViewModel
            {
                GameCollectionItems = games,
                CollectionValue = games.Sum(a => a.Value),
                TotalYouPaid = games.Sum(a => a.Cost),
            };
            return this.View(viewModel);
        }

        public async Task<IActionResult> SearchUser()
        {
            var user = await this.userManager.GetUserAsync(this.User);

            return this.RedirectToAction("AllCollection", new { userId = user.Id });
        }
    }
}
