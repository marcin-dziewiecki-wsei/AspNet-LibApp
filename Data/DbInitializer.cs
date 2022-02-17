using LibApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace LibApp.Data
{
    public static class DbInitializer
    {
        public static async Task<IHost> UseDatabaseAutoMigration(this IHost app)
        {
            using (var scope = app.Services.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                await context.Database.MigrateAsync();
            }
            return app;
        }

        public static async Task<IHost> UseDatabaseSeed(this IHost app)
        {
            using (var scope = app.Services.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                await SeedMembershipTypes(context);
            }
            return app;
        }

        private static async Task SeedMembershipTypes(ApplicationDbContext context)
        {
            if (context.MembershipTypes.Any())
            {
                Console.WriteLine("MembershipTypes already seeded");
                return;
            }

            context.MembershipTypes.AddRange(
                new MembershipType
                {
                    Id = 1,
                    SignUpFee = 0,
                    DurationInMonths = 0,
                    DiscountRate = 0
                },
                new MembershipType
                {
                    Id = 2,
                    SignUpFee = 30,
                    DurationInMonths = 1,
                    DiscountRate = 10
                },
                new MembershipType
                {
                    Id = 3,
                    SignUpFee = 90,
                    DurationInMonths = 3,
                    DiscountRate = 15
                },
                new MembershipType
                {
                    Id = 4,
                    SignUpFee = 300,
                    DurationInMonths = 12,
                    DiscountRate = 20
                });

            await context.SaveChangesAsync();
        }
    }
}
