using LibApp.Domain.Models.Abstractions;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibApp.Data.Data.Seed
{
    public static partial class DbInitializer
    {
        private static async Task<IList<T>> GetCollection<T>(ApplicationDbContext context) where T : EntityBase
        {
            return await context.Set<T>().Take(10).ToListAsync();
        }

        private static async Task AddCollection<T>(this IList<T> collection, ApplicationDbContext context, bool identityInsert = false) where T : EntityBase
        {
            await context.AddRangeAsync(collection);

            if (identityInsert)
                await context.SaveChangesWithIdentityInsert<T>();
            else
                await context.SaveChangesAsync();
        }

        private static T TakeAtIndexOrLast<T>(this IList<T> collection, int index) where T : EntityBase
        {
            return collection.Skip(index).FirstOrDefault() ?? collection.Last();
        }

        private static async Task EnableIdentityInsert<T>(this DbContext context) => await SetIdentityInsert<T>(context, enable: true);
        private static async Task DisableIdentityInsert<T>(this DbContext context) => await SetIdentityInsert<T>(context, enable: false);

        private static async Task<int> SetIdentityInsert<T>(DbContext context, bool enable)
        {
            var entityType = context.Model.FindEntityType(typeof(T));
            var value = enable ? "ON" : "OFF";
            return await context.Database.ExecuteSqlRawAsync(
                $"SET IDENTITY_INSERT {entityType.GetSchema()}.{entityType.GetTableName()} {value}");
        }

        private static async Task SaveChangesWithIdentityInsert<T>(this DbContext context)
        {
            using var transaction = await context.Database.BeginTransactionAsync();
            await context.EnableIdentityInsert<T>();
            await context.SaveChangesAsync();
            await context.DisableIdentityInsert<T>();
            await transaction.CommitAsync();
        }
    }
}
