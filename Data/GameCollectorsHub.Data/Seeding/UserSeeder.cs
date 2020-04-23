namespace GameCollectorsHub.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using GameCollectorsHub.Common;

    public class UserSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Users.Any())
            {
                return;
            }

            var users = new List<(string, string, string)>()
            {
                ("admin", "admin@admin.com", "AQAAAAEAACcQAAAAEEXh0uVMta3TpJTb9f5HLaWCNo5dYKJLz+Nf3h/HME1d4Fu4j8aFCsXA7S8XMrugXQ=="),
            };

            foreach (var user in users)
            {
                var guid = Guid.NewGuid().ToString();

                await dbContext.Users.AddAsync(new Models.ApplicationUser
                {
                    Id = guid,
                    UserName = user.Item1,
                    NormalizedUserName = user.Item1.ToUpper(),
                    Email = user.Item2,
                    NormalizedEmail = user.Item2.ToUpper(),
                    PasswordHash = user.Item3,
                });

                var admin = dbContext.Roles.Where(a => a.Name == GlobalConstants.AdministratorRoleName).FirstOrDefault();

                dbContext.UserRoles.Add(new Microsoft.AspNetCore.Identity.IdentityUserRole<string> { UserId = guid, RoleId = admin.Id });
            }
        }
    }
}
