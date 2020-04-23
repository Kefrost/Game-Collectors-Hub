using GameCollectorsHub.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCollectorsHub.Data.Seeding
{
   public class ConsolesSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.GameConsoles.Any())
            {
                return;
            }

            var consoles = new List<(string, string, DateTime, decimal, string, string, int, int)>()
            {
                ("Nintendo 3DS XL", "https://images-na.ssl-images-amazon.com/images/I/81%2BCWBzwsDL._SL1500_.jpg", DateTime.UtcNow, 199.99m,"Lorem ipsum dolor sit amet, consectetur adipiscing elit. Mauris blandit consequat mauris, non tincidunt ipsum iaculis sed. Pellentesque at pulvinar urna. Ut quis urna vitae nibh commodo volutpat ut at nulla. Donec consequat et nisi vitae volutpat. Maecenas consectetur ornare nibh, quis sagittis purus mattis ut. Sed sapien tellus, faucibus at rhoncus sit amet, suscipit vitae tellus. Mauris imperdiet leo nibh, eu aliquam arcu tincidunt vel. Donec nulla tellus, consequat at efficitur sed, tristique ut massa. Nunc euismod dignissim tortor, at vehicula tellus. Nam pharetra mauris felis, in dignissim felis consectetur sit amet. Nulla auctor tortor tortor, eget laoreet augue pharetra non.", "Pokémon X & Y Limited Edition Red", 1000, dbContext.Platforms.Where(a => a.Name == "Nintendo 3DS").FirstOrDefault().Id),
                ("Nintendo 3DS", "https://images-na.ssl-images-amazon.com/images/I/81Vbrlh0hbL._AC_SX569_.jpg", DateTime.UtcNow, 199.99m,"Lorem ipsum dolor sit amet, consectetur adipiscing elit. Mauris blandit consequat mauris, non tincidunt ipsum iaculis sed. Pellentesque at pulvinar urna. Ut quis urna vitae nibh commodo volutpat ut at nulla. Donec consequat et nisi vitae volutpat. Maecenas consectetur ornare nibh, quis sagittis purus mattis ut. Sed sapien tellus, faucibus at rhoncus sit amet, suscipit vitae tellus. Mauris imperdiet leo nibh, eu aliquam arcu tincidunt vel. Donec nulla tellus, consequat at efficitur sed, tristique ut massa. Nunc euismod dignissim tortor, at vehicula tellus. Nam pharetra mauris felis, in dignissim felis consectetur sit amet. Nulla auctor tortor tortor, eget laoreet augue pharetra non.", "Limited Edition Legend of Zelda: Ocarina of Time", 1000, dbContext.Platforms.Where(a => a.Name == "Nintendo 3DS").FirstOrDefault().Id),
                ("Nintendo 3DS", "https://images-na.ssl-images-amazon.com/images/I/81ol5avRjpL._AC_SL1500_.jpg", DateTime.UtcNow, 199.99m,"Lorem ipsum dolor sit amet, consectetur adipiscing elit. Mauris blandit consequat mauris, non tincidunt ipsum iaculis sed. Pellentesque at pulvinar urna. Ut quis urna vitae nibh commodo volutpat ut at nulla. Donec consequat et nisi vitae volutpat. Maecenas consectetur ornare nibh, quis sagittis purus mattis ut. Sed sapien tellus, faucibus at rhoncus sit amet, suscipit vitae tellus. Mauris imperdiet leo nibh, eu aliquam arcu tincidunt vel. Donec nulla tellus, consequat at efficitur sed, tristique ut massa. Nunc euismod dignissim tortor, at vehicula tellus. Nam pharetra mauris felis, in dignissim felis consectetur sit amet. Nulla auctor tortor tortor, eget laoreet augue pharetra non.", "Aqua Blue", 1000, dbContext.Platforms.Where(a => a.Name == "Nintendo 3DS").FirstOrDefault().Id),
            };

            foreach (var console in consoles)
            {
                await dbContext.GameConsoles.AddAsync(new GameConsole
                {
                    Name = console.Item1,
                    ImgUrl = console.Item2,
                    ReleaseDate = console.Item3,
                    InitialPrice = console.Item4,
                    Description = console.Item5,
                    Model = console.Item6,
                    GamesReleased = console.Item7,
                    PlatformId = console.Item8,
                });
            }
        }
    }
}
