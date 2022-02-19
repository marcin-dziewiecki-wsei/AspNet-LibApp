using LibApp.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibApp.Data
{
    public static partial class DbInitializer
    {
        private static async Task<IList<MembershipType>> SeedMembershipTypes(ApplicationDbContext context)
        {
            var collection = await GetCollection<MembershipType>(context);
            if (collection.Any()) return collection;

            var collectionToAdd = new List<MembershipType> {
                new MembershipType
                {
                    SignUpFee = 0,
                    DurationInMonths = 0,
                    DiscountRate = 0,
                    Name = "Free"
                },
                new MembershipType
                {
                    SignUpFee = 30,
                    DurationInMonths = 1,
                    DiscountRate = 10,
                    Name = "Standard"
                },
                new MembershipType
                {
                    SignUpFee = 90,
                    DurationInMonths = 3,
                    DiscountRate = 15,
                    Name = "Silver"
                },
                new MembershipType
                {
                    SignUpFee = 300,
                    DurationInMonths = 12,
                    DiscountRate = 20,
                    Name = "Gold"
                }
            };

            await collectionToAdd.AddCollection(context);
            return collectionToAdd;
        }
    }
}
