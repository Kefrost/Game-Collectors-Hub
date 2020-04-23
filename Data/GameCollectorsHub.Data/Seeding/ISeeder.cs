namespace GameCollectorsHub.Data.Seeding
{
    using GameCollectorsHub.Data.Models;
    using Microsoft.AspNetCore.Identity;
    using System;
    using System.Threading.Tasks;

    public interface ISeeder
    {
        Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider);

    }
}
