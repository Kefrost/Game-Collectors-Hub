namespace GameCollectorsHub.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using GameCollectorsHub.Data.Models;

    public class PlatformSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Platforms.Any())
            {
                return;
            }

            var platforms = new List<(string, string)>()
            {
                ("Nintendo NES", "https://upload.wikimedia.org/wikipedia/commons/7/7a/Wikipedia_NES_PAL.jpg"),
                ("Nintendo SNES", "https://images-eu.ssl-images-amazon.com/images/G/02/uk-videogames/2014/ConsoleComp/aplus/SNES_Console_lg._V344019168_.jpg"),
                ("Nintendo 64", "https://images-na.ssl-images-amazon.com/images/I/71Te2sR17LL._SL1500_.jpg"),
                ("Nintendo Gamecube", "https://vignette.wikia.nocookie.net/mariokart/images/d/d0/4.jpg/revision/latest?cb=20140608161714"),
                ("Nintendo Wii", "https://www.extremetech.com/wp-content/uploads/2019/01/wii-640x353.jpg"),
                ("Nintendo Wii U", "https://s12emagst.akamaized.net/products/2513/2512718/images/res_08ff9a38f60f34deac073855e0ebb3b5_full.jpg"),
                ("Nintendo GameBoy", "https://images-na.ssl-images-amazon.com/images/I/51RzsM9bJWL._SL1280_.jpg"),
                ("Nintendo GameBoy Color", "https://media.gamestop.com/i/gamestop/10131400/Nintendo-Game-Boy-Color---Kiwi?$pdp$"),
                ("Nintendo GameBoy Advance", "https://images-na.ssl-images-amazon.com/images/I/91rHLnOwrhL._AC_SL1500_.jpg"),
                ("Nintendo DS", "https://upload.wikimedia.org/wikipedia/commons/thumb/d/d5/Nintendo-ds-lite.svg/1093px-Nintendo-ds-lite.svg.png"),
                ("Nintendo 3DS", "https://uk.static.webuy.com/product_images/Gaming/3DS%20Consoles/0454965003DAB03_l.jpg"),
                ("Nintendo Switch", "https://cdn.ozone.bg/media/catalog/product/cache/1/image/a4e40ebdc3e371adff845072e1c73f37/n/i/2ea10096ed5223460c717ae02f879d4d/nintendo-switch---gray-314.jpg"),
                ("Playstation 1", "https://media.gamestop.com/i/gamestop/10122936/PlayStation-System?$zoom$"),
                ("Playstation 2", "https://mobilebulgaria.com/img/cms/996/743996.jpg"),
                ("Playstation 3", "https://upload.wikimedia.org/wikipedia/commons/d/d3/Sony-PlayStation-3-2001A-wController-L.jpg"),
                ("Playstation 4", "https://s12emagst.akamaized.net/products/4152/4151785/images/res_f7edf2e40f22326abc00920ddb0fd2f0_full.jpg"),
                ("Playstation Portable", "https://mobilebulgaria.com/img/cms/109/254109.jpg"),
                ("Playstation Vita", "https://cdn.technomarket.bg/media/cache/mid_thumb/uploads/library/product/09117140/560b18af3e85f.png"),
                ("Xbox", "https://upload.wikimedia.org/wikipedia/commons/4/43/Xbox-console.jpg"),
                ("Xbox 360", "https://www.gamesmen.com.au/media/catalog/product/cache/1/image/9df78eab33525d08d6e5fb8d27136e95/x/b/xbox_360_s_black_console_pre-owned_1__2.jpg"),
                ("Xbox One", "https://media.gamestop.com/i/gamestop/10174659/Xbox-One-X-Black-1TB?$pdp$"),
            };

            foreach (var platform in platforms)
            {
                await dbContext.Platforms.AddAsync(new Platform
                {
                    Name = platform.Item1,
                    ImageUrl = platform.Item2,
                });
            }
        }
    }
}
