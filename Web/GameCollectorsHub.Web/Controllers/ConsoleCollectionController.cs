namespace GameCollectorsHub.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using GameCollectorsHub.Data.Models;
    using GameCollectorsHub.Services.Data;
    using GameCollectorsHub.Web.ViewModels.ConsoleCollection;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    public class ConsoleCollectionController : Controller
    {
        private readonly IConsoleCollectionService service;
        private readonly UserManager<ApplicationUser> userManager;

        public ConsoleCollectionController(IConsoleCollectionService service, UserManager<ApplicationUser> userManager)
        {
            this.service = service;
            this.userManager = userManager;
        }

        public async Task<IActionResult> AllCollection()
        {
            var user = await this.userManager.GetUserAsync(this.User);

            var consoles = this.service.ListAllConsolesCollection(user.Id);

            var viewModel = new AllConsoleCollectionViewModel
            {
                ConsoleCollectionItems = consoles,
                TotalYouPaid = consoles.Sum(a => a.Cost),
            };

            viewModel.TotalYouPaid = Math.Round(viewModel.TotalYouPaid, 3);
            return this.View(viewModel);
        }

        public async Task<IActionResult> SearchUser()
        {
            var user = await this.userManager.GetUserAsync(this.User);

            return this.RedirectToAction("AllCollection", new { userId = user.Id });
        }

        public async Task<IActionResult> Details(int consoleId)
        {
            var user = await this.userManager.GetUserAsync(this.User);

            var viewModel = this.service.GetConsoleCollectionDetails(user.Id, consoleId);

            return this.View(viewModel);
        }

        public async Task<IActionResult> Edit(int consoleId)
        {
            var user = await this.userManager.GetUserAsync(this.User);

            var console = this.service.GetConsoleCollectionInputDetails(user.Id, consoleId);

            var viewModel = new AddConsoleToCollectionInputModel
            {
                ConsoleId = console.ConsoleId,
                ConsoleImgUrl = console.ConsoleImgUrl,
                ConsoleName = console.ConsoleName,
                BoxIncluded = console.BoxIncluded,
                IsItNewAndSealed = console.IsItNewAndSealed,
                PricePaid = console.PricePaid,
            };

            return this.View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(AddConsoleToCollectionInputModel model)
        {
            var user = await this.userManager.GetUserAsync(this.User);

            await this.service.EditConsoleInCollection(model.ConsoleId, user.Id, model.PricePaid, model.BoxIncluded, model.IsItNewAndSealed);

            return this.RedirectToAction("Details", new { consoleId = model.ConsoleId });
        }

        public async Task<IActionResult> Delete(int consoleId)
        {
            var user = await this.userManager.GetUserAsync(this.User);

            var console = this.service.GetConsoleCollectionInputDetails(user.Id, consoleId);

            var viewModel = new AddConsoleToCollectionInputModel
            {
                ConsoleName = console.ConsoleName,
                ConsoleImgUrl = console.ConsoleImgUrl,
                ConsoleId = console.ConsoleId,
                IsItNewAndSealed = console.IsItNewAndSealed,
                PricePaid = console.PricePaid,
            };

            return this.View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteConfirm(int consoleId)
        {
            var user = await this.userManager.GetUserAsync(this.User);

            await this.service.DeleteConsoleInCollectionAsync(user.Id, consoleId);

            return this.RedirectToAction("AllCollection", new { userId = user.Id });
        }
    }
}
