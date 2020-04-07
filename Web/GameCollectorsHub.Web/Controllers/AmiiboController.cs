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
    }
}
