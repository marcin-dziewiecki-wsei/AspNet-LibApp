using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Threading.Tasks;

namespace LibApp.Data.Data.Seed
{
    public static partial class DbInitializer
    {
        public static async Task<IHost> UseDatabaseAutoMigration(this IHost app)
        {
            using (var scope = app.Services.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

                var isNewDatabase = context.Database.CanConnect() == false;
                await context.Database.MigrateAsync();
            }
            return app;
        }

        public static async Task<IHost> UseDatabaseSeed(this IHost app)
        {
            using (var scope = app.Services.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

                var membershipTypes = await SeedMembershipTypes(context);
                var genres = await SeedGenres(context);                
                var books = await SeedBooks(context, genres);
                var customers = await SeedCustomers(context, membershipTypes);
                var rentals = await SeedRentals(context, books, customers);


                var identityRoles = await SeedIdentityRoles(scope);
            }
            return app;
        }       
    }
}
