using LibApp.Domain.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibApp.Data.Data
{
    public static partial class DbInitializer
    {
        private static async Task<IList<Customer>> SeedCustomers(ApplicationDbContext context, IList<MembershipType> membershipTypes)
        {
            var collection = await GetCollection<Customer>(context);
            if (collection.Any()) return collection;

            var collectionToAdd = new List<Customer> {
                new Customer
                {
                    Name = "Mieszko Kaczmarczyk",
                    Birthdate = System.DateTime.Now.AddYears(-23).AddMonths(-4).AddDays(-2),
                    HasNewsletterSubscribed = true,
                    MembershipType = membershipTypes.TakeAtIndexOrLast(0),
                },
                new Customer
                {
                    Name = "Barbara Chmielewska",
                    Birthdate = System.DateTime.Now.AddYears(-19).AddMonths(-1).AddDays(-27),
                    HasNewsletterSubscribed = true,
                    MembershipType = membershipTypes.TakeAtIndexOrLast(1),
                },
                new Customer
                {
                    Name = "Józef Mróz",
                    Birthdate = System.DateTime.Now.AddYears(-13).AddMonths(-7).AddDays(-12),
                    HasNewsletterSubscribed = true,
                    MembershipType = membershipTypes.TakeAtIndexOrLast(2),
                },
                new Customer
                {
                    Name = "Magdalena Laskowska",
                    Birthdate = System.DateTime.Now.AddYears(-26).AddMonths(-3).AddDays(-3),
                    HasNewsletterSubscribed = true,
                    MembershipType = membershipTypes.TakeAtIndexOrLast(3),
                },
                new Customer
                {
                    Name = "Józef Mróz",
                    Birthdate = System.DateTime.Now.AddYears(-43).AddMonths(-2).AddDays(-15),
                    HasNewsletterSubscribed = true,
                    MembershipType = membershipTypes.TakeAtIndexOrLast(0),
                },
                new Customer
                {
                    Name = "Emil Czerwiński",
                    Birthdate = System.DateTime.Now.AddYears(-53).AddMonths(-8).AddDays(-25),
                    HasNewsletterSubscribed = true,
                    MembershipType = membershipTypes.TakeAtIndexOrLast(1),
                }
            };

            await collectionToAdd.AddCollection(context);
            return collectionToAdd;
        }
    }
}
