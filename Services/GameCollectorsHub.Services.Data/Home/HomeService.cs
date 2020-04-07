namespace GameCollectorsHub.Services.Data.Home
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using GameCollectorsHub.Data.Common.Repositories;
    using GameCollectorsHub.Data.Models;
    using GameCollectorsHub.Web.ViewModels.Home;

    public class HomeService : IHomeService
    {
        private readonly IRepository<Game> game;
        private readonly IRepository<GameConsole> console;
        private readonly IRepository<Amiibo> amiibo;

        public HomeService(IRepository<Game> game, IRepository<GameConsole> console, IRepository<Amiibo> amiibo)
        {
            this.game = game;
            this.console = console;
            this.amiibo = amiibo;
        }

        public HomeViewModel GetAll()
        {
            int gameCount = this.game.All().Count();
            int consolesCount = this.console.All().Count(); 
            int amiiboCount = this.amiibo.All().Count();

            var viewModel = new HomeViewModel { GamesCount = gameCount, ConsolesCount = consolesCount, AmiibosCount = amiiboCount };

            return viewModel;
        }
    }
}
