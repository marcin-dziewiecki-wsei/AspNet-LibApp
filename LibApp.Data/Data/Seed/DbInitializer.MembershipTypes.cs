using LibApp.Domain.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibApp.Data.Data.Seed
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
                    Id = MembershipType.Free,
                    SignUpFee = 0,
                    DurationInMonths = 0,
                    DiscountRate = 0,
                    Name = "Free"
                },
                new MembershipType
                {
                    Id = MembershipType.Standard,
                    SignUpFee = 30,
                    DurationInMonths = 1,
                    DiscountRate = 10,
                    Name = "Standard"
                },
                new MembershipType
                {
                    Id = MembershipType.Silver,
                    SignUpFee = 90,
                    DurationInMonths = 3,
                    DiscountRate = 15,
                    Name = "Silver"
                },
                new MembershipType
                {
                    Id = MembershipType.Gold,
                    SignUpFee = 300,
                    DurationInMonths = 12,
                    DiscountRate = 20,
                    Name = "Gold"
                }
            };

            await collectionToAdd.AddCollection(context, identityInsert: true);
            return collectionToAdd;
        }
    }
}
