using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibApp.Data.Data.Seed
{
    public static partial class DbInitializer
    {
        private static async Task<IList<IdentityRole>> SeedIdentityRoles(IServiceScope scope)
        {
            var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            var collection = await roleManager.Roles.ToListAsync();
            if (collection.Any()) return collection;

            var collectionToAdd = new List<IdentityRole>
            {
                new IdentityRole("User"),
                new IdentityRole("StoreManager"),
                new IdentityRole("Owner")
            };

            foreach (var role in collectionToAdd)
                await roleManager.CreateAsync(role);

            return collectionToAdd;
        }
    }
}
