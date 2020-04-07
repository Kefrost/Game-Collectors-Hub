namespace GameCollectorsHub.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using GameCollectorsHub.Data.Models;

    public class AmiiboSeriesSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.AmiiboSeries.Any())
            {
                return;
            }

            var series = new List<(string, string)>
            {
                ("Animal Crossing", "https://www.stickpng.com/assets/images/5b4a216ec051e602a568cd7e.png"),
                ("Dark Souls", "https://i.pinimg.com/originals/93/34/bc/9334bc5b35f4becd7f38f14bbb31877e.jpg"),
                ("Diablo", "https://www.kindpng.com/picc/m/28-283743_diablo-iii-logo-logo-diablo-3-hd-png.png"),
                ("Fire Emblem", "https://toppng.com/uploads/preview/fire-emblem-logo-11563712806cmskkuwhoo.png"),
                ("Kirby", "https://cdn.freebiesupply.com/logos/thumbs/2x/kirby-4-logo.png"),
                ("Mega Man", "https://upload.wikimedia.org/wikipedia/commons/d/de/Mega_man_logo.png"),
                ("Metroid", "https://toppng.com/uploads/preview/metroid-logo-metroid-11562942354xbg3secte8.png"),
                ("Pokemon", "https://logoeps.com/wp-content/uploads/2012/10/pokemon-logo-vector.png"),
                ("Shovel Knight", "https://www.nicepng.com/png/full/229-2290601_shovel-knight-logo-shovel-knight-amiibo-card.png"),
                ("Splatoon", "https://i.pinimg.com/originals/3c/01/a4/3c01a489e7f4c073bb38a97de5035c19.jpg"),
                ("Super Mario", "https://www.festisite.com/static/partylogo/img/logos/super-mario.png"),
                ("Super Smash Bros.", "https://cdn.mos.cms.futurecdn.net/GXxtjXSBPVyLarX6SkcRvQ.jpg"),
                ("The Legend of Zelda", "https://upload.wikimedia.org/wikipedia/commons/thumb/2/2a/Zelda_Logo.svg/1200px-Zelda_Logo.svg.png"),
            };

            foreach (var serie in series)
            {
                await dbContext.AddAsync(new AmiiboSeries
                {
                    Name = serie.Item1,
                    ImgUrl = serie.Item2,
                });
            }
        }
    }
}
