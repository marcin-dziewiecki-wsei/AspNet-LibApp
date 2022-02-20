using LibApp.Domain.Models.Abstractions;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibApp.Data.Data
{
    public static partial class DbInitializer
    {
        private static async Task<IList<T>> GetCollection<T>(ApplicationDbContext context) where T : EntityBase
        {
            return await context.Set<T>().Take(10).ToListAsync();
        }

        private static async Task AddCollection<T>(this IList<T> collection, ApplicationDbContext context) where T : EntityBase
        {
            foreach (T item in collection)
            {
                await context.AddAsync(item);
            }
            await context.SaveChangesAsync();
        }

        private static T TakeAtIndexOrLast<T>(this IList<T> collection, int index) where T : EntityBase
        {
            return collection.Skip(index).FirstOrDefault() ?? collection.Last();
        }
    }
}
