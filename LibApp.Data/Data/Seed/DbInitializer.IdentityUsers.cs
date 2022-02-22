using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibApp.Data.Data.Seed
{
    public static partial class DbInitializer
    {
        private static async Task<IList<IdentityUser>> SeedIdentityUsers(IServiceScope scope, IList<IdentityRole> identityRoles)
        {
            var userManager = scope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();

            var collection = await userManager.Users.ToListAsync();
            if (collection.Any()) return collection;

            var collectionToAdd = new List<IdentityUser>
            {
                new IdentityUser{ Email = "owner@example.com", EmailConfirmed = true,  },
                new IdentityUser{ Email = "store.manager@example.com", EmailConfirmed = true },
                new IdentityUser{ Email = "user@example.com", EmailConfirmed = true }
            };                

            for (int i = 0; i < 3; i++)
            {
                collectionToAdd[i].UserName = collectionToAdd[i].Email.ToUpperInvariant();

                await userManager.CreateAsync(collectionToAdd[i], "Start123!");
                await userManager.AddToRoleAsync(collectionToAdd[i], identityRoles[i].Name);
            }
                
            return collectionToAdd;
        }
    }
}
