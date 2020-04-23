﻿using GameCollectorsHub.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCollectorsHub.Data.Seeding
{
    public class AmiibosSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Amiibos.Any())
            {
                return;
            }

            var amiibos = new List<(string, string, string, string, DateTime, string, int)>()
            {
                ("Mario", "https://dt2t1o4a01q3k.cloudfront.net/assets/figures/amiibo/super-smash-bros/mario-27f519f25a0da1316f24cc66c3f5f5bbb2c59b080e9dd9c4c571970622a970c3.png", "https://www.pricecharting.com/game/amiibo/mario", "Mario", DateTime.UtcNow, "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Mauris blandit consequat mauris, non tincidunt ipsum iaculis sed. Pellentesque at pulvinar urna. Ut quis urna vitae nibh commodo volutpat ut at nulla. Donec consequat et nisi vitae volutpat. Maecenas consectetur ornare nibh, quis sagittis purus mattis ut. Sed sapien tellus, faucibus at rhoncus sit amet, suscipit vitae tellus. Mauris imperdiet leo nibh, eu aliquam arcu tincidunt vel. Donec nulla tellus, consequat at efficitur sed, tristique ut massa. Nunc euismod dignissim tortor, at vehicula tellus. Nam pharetra mauris felis, in dignissim felis consectetur sit amet. Nulla auctor tortor tortor, eget laoreet augue pharetra non.", dbContext.AmiiboSeries.Where(a => a.Name == "Super Smash Bros.").FirstOrDefault().Id),
                ("Peach", "https://dt2t1o4a01q3k.cloudfront.net/assets/figures/amiibo/super-smash-bros/peach-b18791e26bd729159ae8bb81aab687e79179525c4b757a8a90fa1383b2e26bba.png", "https://www.pricecharting.com/game/amiibo/peach", "Mario", DateTime.UtcNow, "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Mauris blandit consequat mauris, non tincidunt ipsum iaculis sed. Pellentesque at pulvinar urna. Ut quis urna vitae nibh commodo volutpat ut at nulla. Donec consequat et nisi vitae volutpat. Maecenas consectetur ornare nibh, quis sagittis purus mattis ut. Sed sapien tellus, faucibus at rhoncus sit amet, suscipit vitae tellus. Mauris imperdiet leo nibh, eu aliquam arcu tincidunt vel. Donec nulla tellus, consequat at efficitur sed, tristique ut massa. Nunc euismod dignissim tortor, at vehicula tellus. Nam pharetra mauris felis, in dignissim felis consectetur sit amet. Nulla auctor tortor tortor, eget laoreet augue pharetra non.", dbContext.AmiiboSeries.Where(a => a.Name == "Super Smash Bros.").FirstOrDefault().Id),
                ("Yoshi", "https://dt2t1o4a01q3k.cloudfront.net/assets/figures/amiibo/super-smash-bros/yoshi-0801b9796802bb686add1af2b71c82d299ebdb76f301e34d333807820ace5217.png", "https://www.pricecharting.com/game/amiibo/yoshi", "Mario", DateTime.UtcNow, "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Mauris blandit consequat mauris, non tincidunt ipsum iaculis sed. Pellentesque at pulvinar urna. Ut quis urna vitae nibh commodo volutpat ut at nulla. Donec consequat et nisi vitae volutpat. Maecenas consectetur ornare nibh, quis sagittis purus mattis ut. Sed sapien tellus, faucibus at rhoncus sit amet, suscipit vitae tellus. Mauris imperdiet leo nibh, eu aliquam arcu tincidunt vel. Donec nulla tellus, consequat at efficitur sed, tristique ut massa. Nunc euismod dignissim tortor, at vehicula tellus. Nam pharetra mauris felis, in dignissim felis consectetur sit amet. Nulla auctor tortor tortor, eget laoreet augue pharetra non.", dbContext.AmiiboSeries.Where(a => a.Name == "Super Smash Bros.").FirstOrDefault().Id),
                ("Samus", "https://dt2t1o4a01q3k.cloudfront.net/assets/figures/amiibo/super-smash-bros/samus-7531679eb7ffe793e3f919cee370e7fd0b856d6bb79be90ddb398e4a70779ca0.png", "https://www.pricecharting.com/game/amiibo/samus", "Metroid", DateTime.UtcNow, "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Mauris blandit consequat mauris, non tincidunt ipsum iaculis sed. Pellentesque at pulvinar urna. Ut quis urna vitae nibh commodo volutpat ut at nulla. Donec consequat et nisi vitae volutpat. Maecenas consectetur ornare nibh, quis sagittis purus mattis ut. Sed sapien tellus, faucibus at rhoncus sit amet, suscipit vitae tellus. Mauris imperdiet leo nibh, eu aliquam arcu tincidunt vel. Donec nulla tellus, consequat at efficitur sed, tristique ut massa. Nunc euismod dignissim tortor, at vehicula tellus. Nam pharetra mauris felis, in dignissim felis consectetur sit amet. Nulla auctor tortor tortor, eget laoreet augue pharetra non.", dbContext.AmiiboSeries.Where(a => a.Name == "Super Smash Bros.").FirstOrDefault().Id),
                ("Pikachu", "https://dt2t1o4a01q3k.cloudfront.net/assets/figures/amiibo/super-smash-bros/pikachu-8946aabb1e355ca71416aa1548730b7f416f81d664859e038fc297559a2976f4.png", "https://www.pricecharting.com/game/amiibo/pikachu", "Pokemon", DateTime.UtcNow, "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Mauris blandit consequat mauris, non tincidunt ipsum iaculis sed. Pellentesque at pulvinar urna. Ut quis urna vitae nibh commodo volutpat ut at nulla. Donec consequat et nisi vitae volutpat. Maecenas consectetur ornare nibh, quis sagittis purus mattis ut. Sed sapien tellus, faucibus at rhoncus sit amet, suscipit vitae tellus. Mauris imperdiet leo nibh, eu aliquam arcu tincidunt vel. Donec nulla tellus, consequat at efficitur sed, tristique ut massa. Nunc euismod dignissim tortor, at vehicula tellus. Nam pharetra mauris felis, in dignissim felis consectetur sit amet. Nulla auctor tortor tortor, eget laoreet augue pharetra non.", dbContext.AmiiboSeries.Where(a => a.Name == "Super Smash Bros.").FirstOrDefault().Id),
                ("Rosalina", "https://dt2t1o4a01q3k.cloudfront.net/assets/figures/amiibo/super-smash-bros/rosalina-6fd7b72f939904f97a22a5a3eb0f7db5f9854cf5f4b019159d18ef48793ce4f1.png", "https://www.pricecharting.com/game/amiibo/rosalina", "Mario", DateTime.UtcNow, "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Mauris blandit consequat mauris, non tincidunt ipsum iaculis sed. Pellentesque at pulvinar urna. Ut quis urna vitae nibh commodo volutpat ut at nulla. Donec consequat et nisi vitae volutpat. Maecenas consectetur ornare nibh, quis sagittis purus mattis ut. Sed sapien tellus, faucibus at rhoncus sit amet, suscipit vitae tellus. Mauris imperdiet leo nibh, eu aliquam arcu tincidunt vel. Donec nulla tellus, consequat at efficitur sed, tristique ut massa. Nunc euismod dignissim tortor, at vehicula tellus. Nam pharetra mauris felis, in dignissim felis consectetur sit amet. Nulla auctor tortor tortor, eget laoreet augue pharetra non.", dbContext.AmiiboSeries.Where(a => a.Name == "Super Smash Bros.").FirstOrDefault().Id),
                ("Bowser", "https://dt2t1o4a01q3k.cloudfront.net/assets/figures/amiibo/super-smash-bros/bowser-8550e0ee2b6a688b129e9d547b5cef891df7af2fedfce4504373787c03e9d9b6.png", "https://www.pricecharting.com/game/amiibo/bowser", "Mario", DateTime.UtcNow, "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Mauris blandit consequat mauris, non tincidunt ipsum iaculis sed. Pellentesque at pulvinar urna. Ut quis urna vitae nibh commodo volutpat ut at nulla. Donec consequat et nisi vitae volutpat. Maecenas consectetur ornare nibh, quis sagittis purus mattis ut. Sed sapien tellus, faucibus at rhoncus sit amet, suscipit vitae tellus. Mauris imperdiet leo nibh, eu aliquam arcu tincidunt vel. Donec nulla tellus, consequat at efficitur sed, tristique ut massa. Nunc euismod dignissim tortor, at vehicula tellus. Nam pharetra mauris felis, in dignissim felis consectetur sit amet. Nulla auctor tortor tortor, eget laoreet augue pharetra non.", dbContext.AmiiboSeries.Where(a => a.Name == "Super Smash Bros.").FirstOrDefault().Id),
                ("Lucario", "https://dt2t1o4a01q3k.cloudfront.net/assets/figures/amiibo/super-smash-bros/lucario-e8cf3ccee0719965558df5f6640a01d74aed23ad31d1c38f796085fe1ea35d2c.png", "https://www.pricecharting.com/game/amiibo/lucario?q=lucario", "Pokemon", DateTime.UtcNow, "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Mauris blandit consequat mauris, non tincidunt ipsum iaculis sed. Pellentesque at pulvinar urna. Ut quis urna vitae nibh commodo volutpat ut at nulla. Donec consequat et nisi vitae volutpat. Maecenas consectetur ornare nibh, quis sagittis purus mattis ut. Sed sapien tellus, faucibus at rhoncus sit amet, suscipit vitae tellus. Mauris imperdiet leo nibh, eu aliquam arcu tincidunt vel. Donec nulla tellus, consequat at efficitur sed, tristique ut massa. Nunc euismod dignissim tortor, at vehicula tellus. Nam pharetra mauris felis, in dignissim felis consectetur sit amet. Nulla auctor tortor tortor, eget laoreet augue pharetra non.", dbContext.AmiiboSeries.Where(a => a.Name == "Super Smash Bros.").FirstOrDefault().Id),
                ("Charizard", "https://dt2t1o4a01q3k.cloudfront.net/assets/figures/amiibo/super-smash-bros/charizard-cc9773c88158675adc1b9c8d08e4735e600ee5595249ba5e09984790f2282013.png", "https://www.pricecharting.com/game/amiibo/charizard?q=charizard", "Pokemon", DateTime.UtcNow, "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Mauris blandit consequat mauris, non tincidunt ipsum iaculis sed. Pellentesque at pulvinar urna. Ut quis urna vitae nibh commodo volutpat ut at nulla. Donec consequat et nisi vitae volutpat. Maecenas consectetur ornare nibh, quis sagittis purus mattis ut. Sed sapien tellus, faucibus at rhoncus sit amet, suscipit vitae tellus. Mauris imperdiet leo nibh, eu aliquam arcu tincidunt vel. Donec nulla tellus, consequat at efficitur sed, tristique ut massa. Nunc euismod dignissim tortor, at vehicula tellus. Nam pharetra mauris felis, in dignissim felis consectetur sit amet. Nulla auctor tortor tortor, eget laoreet augue pharetra non.", dbContext.AmiiboSeries.Where(a => a.Name == "Super Smash Bros.").FirstOrDefault().Id),
                ("Zero Suit Samus", "https://dt2t1o4a01q3k.cloudfront.net/assets/figures/amiibo/super-smash-bros/zero-suit-samus-45c311e20a48da3e0bf0e8da9035878c9c86d693eed5e1c82c85a8ea80fc7562.png", "https://www.pricecharting.com/game/amiibo/samus-zero-suit?q=zero+suit+samus", "Metroid", DateTime.UtcNow, "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Mauris blandit consequat mauris, non tincidunt ipsum iaculis sed. Pellentesque at pulvinar urna. Ut quis urna vitae nibh commodo volutpat ut at nulla. Donec consequat et nisi vitae volutpat. Maecenas consectetur ornare nibh, quis sagittis purus mattis ut. Sed sapien tellus, faucibus at rhoncus sit amet, suscipit vitae tellus. Mauris imperdiet leo nibh, eu aliquam arcu tincidunt vel. Donec nulla tellus, consequat at efficitur sed, tristique ut massa. Nunc euismod dignissim tortor, at vehicula tellus. Nam pharetra mauris felis, in dignissim felis consectetur sit amet. Nulla auctor tortor tortor, eget laoreet augue pharetra non.", dbContext.AmiiboSeries.Where(a => a.Name == "Super Smash Bros.").FirstOrDefault().Id),
                ("Duck Hunt", "https://dt2t1o4a01q3k.cloudfront.net/assets/figures/amiibo/super-smash-bros/duck-hunt-b23f0c806f35df695aa136557de687c4bff38bc2fd8b9d854a6a7cb437d57515.png", "https://www.pricecharting.com/game/amiibo/duck-hunt", "Retro Nintendo", DateTime.UtcNow, "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Mauris blandit consequat mauris, non tincidunt ipsum iaculis sed. Pellentesque at pulvinar urna. Ut quis urna vitae nibh commodo volutpat ut at nulla. Donec consequat et nisi vitae volutpat. Maecenas consectetur ornare nibh, quis sagittis purus mattis ut. Sed sapien tellus, faucibus at rhoncus sit amet, suscipit vitae tellus. Mauris imperdiet leo nibh, eu aliquam arcu tincidunt vel. Donec nulla tellus, consequat at efficitur sed, tristique ut massa. Nunc euismod dignissim tortor, at vehicula tellus. Nam pharetra mauris felis, in dignissim felis consectetur sit amet. Nulla auctor tortor tortor, eget laoreet augue pharetra non.", dbContext.AmiiboSeries.Where(a => a.Name == "Super Smash Bros.").FirstOrDefault().Id),
                ("Mewtwo", "https://dt2t1o4a01q3k.cloudfront.net/assets/figures/amiibo/super-smash-bros/mewtwo-ba13e67a85ad6e6df98143165f3e77fb57020315d0fef537db367de7da8ae9ba.png", "https://www.pricecharting.com/game/amiibo/mewtwo?q=mewtwo", "Pokemon", DateTime.UtcNow, "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Mauris blandit consequat mauris, non tincidunt ipsum iaculis sed. Pellentesque at pulvinar urna. Ut quis urna vitae nibh commodo volutpat ut at nulla. Donec consequat et nisi vitae volutpat. Maecenas consectetur ornare nibh, quis sagittis purus mattis ut. Sed sapien tellus, faucibus at rhoncus sit amet, suscipit vitae tellus. Mauris imperdiet leo nibh, eu aliquam arcu tincidunt vel. Donec nulla tellus, consequat at efficitur sed, tristique ut massa. Nunc euismod dignissim tortor, at vehicula tellus. Nam pharetra mauris felis, in dignissim felis consectetur sit amet. Nulla auctor tortor tortor, eget laoreet augue pharetra non.", dbContext.AmiiboSeries.Where(a => a.Name == "Super Smash Bros.").FirstOrDefault().Id),
                ("Ryu", "https://dt2t1o4a01q3k.cloudfront.net/assets/figures/amiibo/super-smash-bros/ryu-4bc85b2e7534d1a93b3070f0933418f4930d67cfbacc20e3c4cb5cabe07e4c81.png", "https://www.pricecharting.com/game/amiibo/ryu", "Street Fighter", DateTime.UtcNow, "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Mauris blandit consequat mauris, non tincidunt ipsum iaculis sed. Pellentesque at pulvinar urna. Ut quis urna vitae nibh commodo volutpat ut at nulla. Donec consequat et nisi vitae volutpat. Maecenas consectetur ornare nibh, quis sagittis purus mattis ut. Sed sapien tellus, faucibus at rhoncus sit amet, suscipit vitae tellus. Mauris imperdiet leo nibh, eu aliquam arcu tincidunt vel. Donec nulla tellus, consequat at efficitur sed, tristique ut massa. Nunc euismod dignissim tortor, at vehicula tellus. Nam pharetra mauris felis, in dignissim felis consectetur sit amet. Nulla auctor tortor tortor, eget laoreet augue pharetra non.", dbContext.AmiiboSeries.Where(a => a.Name == "Super Smash Bros.").FirstOrDefault().Id),
                ("Bayonetta", "https://dt2t1o4a01q3k.cloudfront.net/assets/figures/amiibo/super-smash-bros/bayonetta-d0e033472ab3d6c839f6325924084aeda890931175075056055d39b12cecf164.png", "https://www.pricecharting.com/game/amiibo/bayonetta", "Bayonetta", DateTime.UtcNow, "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Mauris blandit consequat mauris, non tincidunt ipsum iaculis sed. Pellentesque at pulvinar urna. Ut quis urna vitae nibh commodo volutpat ut at nulla. Donec consequat et nisi vitae volutpat. Maecenas consectetur ornare nibh, quis sagittis purus mattis ut. Sed sapien tellus, faucibus at rhoncus sit amet, suscipit vitae tellus. Mauris imperdiet leo nibh, eu aliquam arcu tincidunt vel. Donec nulla tellus, consequat at efficitur sed, tristique ut massa. Nunc euismod dignissim tortor, at vehicula tellus. Nam pharetra mauris felis, in dignissim felis consectetur sit amet. Nulla auctor tortor tortor, eget laoreet augue pharetra non.", dbContext.AmiiboSeries.Where(a => a.Name == "Super Smash Bros.").FirstOrDefault().Id),
                ("Piranha Plant", "https://dt2t1o4a01q3k.cloudfront.net/assets/figures/amiibo/super-smash-bros/piranha-plant-4383286615bfb098a76a7b20e1268848b7997386f0c400beca0bbe18d15a589a.png", "https://www.pricecharting.com/game/amiibo/piranha-plant?q=piranha+plant", "Mario", DateTime.UtcNow, "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Mauris blandit consequat mauris, non tincidunt ipsum iaculis sed. Pellentesque at pulvinar urna. Ut quis urna vitae nibh commodo volutpat ut at nulla. Donec consequat et nisi vitae volutpat. Maecenas consectetur ornare nibh, quis sagittis purus mattis ut. Sed sapien tellus, faucibus at rhoncus sit amet, suscipit vitae tellus. Mauris imperdiet leo nibh, eu aliquam arcu tincidunt vel. Donec nulla tellus, consequat at efficitur sed, tristique ut massa. Nunc euismod dignissim tortor, at vehicula tellus. Nam pharetra mauris felis, in dignissim felis consectetur sit amet. Nulla auctor tortor tortor, eget laoreet augue pharetra non.", dbContext.AmiiboSeries.Where(a => a.Name == "Super Smash Bros.").FirstOrDefault().Id),

            };

            foreach (var amiibo in amiibos)
            {
                await dbContext.Amiibos.AddAsync(new Amiibo
                {
                    Name = amiibo.Item1,
                    ImgUrl = amiibo.Item2,
                    PriceUrl = amiibo.Item3,
                    Franchise = amiibo.Item4,
                    ReleaseDate = amiibo.Item5,
                    Description = amiibo.Item6,
                    AmiiboSeriesId = amiibo.Item7,
                });
            }
        }
    }
}
