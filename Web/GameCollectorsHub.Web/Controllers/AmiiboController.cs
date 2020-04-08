namespace GameCollectorsHub.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using GameCollectorsHub.Services.Data;
    using GameCollectorsHub.Web.ViewModels.Amiibo;
    using Microsoft.AspNetCore.Mvc;

    public class AmiiboController : Controller
    {
        private readonly IAmiiboService service;

        public AmiiboController(IAmiiboService service)
        {
            this.service = service;
        }

        public IActionResult Series()
        {
            var series = this.service.GetAmiiboSeries();

            var viewModel = new AmiiboSeriesViewModel { AmiiboSeries = series };

            return this.View(viewModel);
        }

        public IActionResult Details(int id)
        {
            return this.View();
        }

        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
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
    }
}
