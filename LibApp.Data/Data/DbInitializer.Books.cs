using LibApp.Domain.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibApp.Data.Data
{
    public static partial class DbInitializer
    {
        private static async Task<IList<Book>> SeedBooks(ApplicationDbContext context, IList<Genre> genres)
        {
            var collection = await GetCollection<Book>(context);
            if (collection.Any()) return collection;

            var collectionToAdd = new List<Book> {
                new Book
                {
                    AuthorName = "Krzysztof Kowalski",
                    DateAdded = System.DateTime.Now.AddYears(-1).AddMonths(-4).AddDays(-5),
                    Genre = genres.TakeAtIndexOrLast(0),
                    Name = "Book Title written by K.Kowalski",
                    NumberAvailable = 5,
                    NumberInStock = 5,
                    ReleaseDate = System.DateTime.Now.AddYears(-2).AddMonths(-3).AddDays(-4)
                },
                new Book
                {
                    AuthorName = "Jan Nowak",
                    DateAdded = System.DateTime.Now.AddYears(-1).AddMonths(-8).AddDays(-14),
                    Genre = genres.TakeAtIndexOrLast(1),
                    Name = "Book Title written by J.Nowak",
                    NumberAvailable = 10,
                    NumberInStock = 10,
                    ReleaseDate = System.DateTime.Now.AddYears(-3).AddMonths(-4).AddDays(-23)
                },
                new Book
                {
                    AuthorName = "Tomasz Sztuczny",
                    DateAdded = System.DateTime.Now.AddYears(-1).AddMonths(-6).AddDays(-1),
                    Genre = genres.TakeAtIndexOrLast(2),
                    Name = "Book Title written by T.Sztuczny",
                    NumberAvailable = 15,
                    NumberInStock = 15,
                    ReleaseDate = System.DateTime.Now.AddYears(-4).AddMonths(-5).AddDays(-6)
                },
                new Book
                {
                    AuthorName = "Maja Szewczyk",
                    DateAdded = System.DateTime.Now.AddYears(-1).AddMonths(-4).AddDays(-27),
                    Genre = genres.TakeAtIndexOrLast(1),
                    Name = "Book Title written by M.Szewczyk",
                    NumberAvailable = 15,
                    NumberInStock = 15,
                    ReleaseDate = System.DateTime.Now.AddYears(-4).AddMonths(-5).AddDays(-6)
                },
                new Book
                {
                    AuthorName = "Otylia Brzezińska",
                    DateAdded = System.DateTime.Now.AddYears(-1).AddMonths(-2).AddDays(-6),
                    Genre = genres.TakeAtIndexOrLast(1),
                    Name = "Book Title written by O.Brzezińska",
                    NumberAvailable = 15,
                    NumberInStock = 15,
                    ReleaseDate = System.DateTime.Now.AddYears(-4).AddMonths(-5).AddDays(-6)
                }
            };

            await collectionToAdd.AddCollection(context);
            return collectionToAdd;
        }
    }
}
