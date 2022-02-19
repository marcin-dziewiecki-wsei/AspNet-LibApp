using LibApp.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibApp.Data
{
    public static partial class DbInitializer
    {
        private static async Task<IList<Genre>> SeedGenres(ApplicationDbContext context)
        {
            var collection = await GetCollection<Genre>(context);
            if (collection.Any()) return collection;

            var collectionToAdd = new List<Genre> {
                new Genre
                {
                    Name = "Fantasy"
                },
                new Genre
                {
                    Name = "Novel"
                },
                new Genre
                {
                    Name = "Thriller"
                },
                new Genre
                {
                    Name = "Comedy"
                },
                new Genre
                {
                    Name = "Action"
                },
                new Genre
                {
                    Name = "Romance"
                },
                new Genre
                {
                    Name = "SciFi"
                }
            };

            await collectionToAdd.AddCollection(context);
            return collectionToAdd;
        }
    }
}
