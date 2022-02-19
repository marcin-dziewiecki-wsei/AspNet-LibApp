using LibApp.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibApp.Data
{
    public static partial class DbInitializer
    {
        private static async Task<IList<Rental>> SeedRentals(ApplicationDbContext context, IList<Book> books, IList<Customer> customers)
        {
            var collection = await GetCollection<Rental>(context);
            if (collection.Any()) return collection;

            var collectionToAdd = new List<Rental> {
                new Rental
                {
                    DateRented = System.DateTime.Now.AddYears(0).AddMonths(-1).AddDays(-27),
                    DateReturned = null,
                    Book = books.TakeAtIndexOrLast(0),
                    Customer = customers.TakeAtIndexOrLast(3)
                },
                new Rental
                {
                    DateRented = System.DateTime.Now.AddYears(0).AddMonths(-2).AddDays(-12),
                    DateReturned = null,
                    Book = books.TakeAtIndexOrLast(1),
                    Customer = customers.TakeAtIndexOrLast(3)
                },
                new Rental
                {
                    DateRented = System.DateTime.Now.AddYears(0).AddMonths(-5).AddDays(-30),
                    DateReturned = System.DateTime.Now.AddYears(0).AddMonths(-2).AddDays(-11),
                    Book = books.TakeAtIndexOrLast(2),
                    Customer = customers.TakeAtIndexOrLast(3)
                },
                new Rental
                {
                    DateRented = System.DateTime.Now.AddYears(0).AddMonths(-3).AddDays(-3),
                    DateReturned = System.DateTime.Now.AddYears(0).AddMonths(-1).AddDays(-21),
                    Book = books.TakeAtIndexOrLast(1),
                    Customer = customers.TakeAtIndexOrLast(2)
                },
                new Rental
                {
                    DateRented = System.DateTime.Now.AddYears(0).AddMonths(-7).AddDays(-5),
                    DateReturned = null,
                    Book = books.TakeAtIndexOrLast(2),
                    Customer = customers.TakeAtIndexOrLast(2)
                },
                new Rental
                {
                    DateRented = System.DateTime.Now.AddYears(0).AddMonths(-1).AddDays(-27),
                    DateReturned = System.DateTime.Now.AddYears(0).AddMonths(-1).AddDays(-5),
                    Book = books.TakeAtIndexOrLast(1),
                    Customer = customers.TakeAtIndexOrLast(1)
                },
                new Rental
                {
                    DateRented = System.DateTime.Now.AddYears(0).AddMonths(-2).AddDays(-17),
                    DateReturned = null,
                    Book = books.TakeAtIndexOrLast(2),
                    Customer = customers.TakeAtIndexOrLast(1)
                },
                new Rental
                {
                    DateRented = System.DateTime.Now.AddYears(0).AddMonths(-12).AddDays(-12),
                    DateReturned = null,
                    Book = books.TakeAtIndexOrLast(3),
                    Customer = customers.TakeAtIndexOrLast(1)
                },
                new Rental
                {
                    DateRented = System.DateTime.Now.AddYears(0).AddMonths(-2).AddDays(-15),
                    DateReturned = System.DateTime.Now.AddYears(0).AddMonths(0).AddDays(-27),
                    Book = books.TakeAtIndexOrLast(1),
                    Customer = customers.TakeAtIndexOrLast(0)
                },
                new Rental
                {
                    DateRented = System.DateTime.Now.AddYears(0).AddMonths(-1).AddDays(-7),
                    DateReturned = System.DateTime.Now.AddYears(0).AddMonths(0).AddDays(-6),
                    Book = books.TakeAtIndexOrLast(2),
                    Customer = customers.TakeAtIndexOrLast(4)
                },
                new Rental
                {
                    DateRented = System.DateTime.Now.AddYears(0).AddMonths(-2).AddDays(-2),
                    DateReturned = System.DateTime.Now.AddYears(0).AddMonths(-1).AddDays(-2),
                    Book = books.TakeAtIndexOrLast(3),
                    Customer = customers.TakeAtIndexOrLast(4)
                }
            };

            await collectionToAdd.AddCollection(context);
            await UpdateBooksAvailabilty(context, books, collectionToAdd);

            return collectionToAdd;
        }

        private static async Task UpdateBooksAvailabilty(ApplicationDbContext context, IList<Book> books, IList<Rental> collection)
        {
            foreach (var book in books)
            {
                book.NumberAvailable -= collection.Where(x => x.Book.Equals(book) && x.DateReturned is null).Count();
            }
            
            await context.SaveChangesAsync();
        }
    }
}
