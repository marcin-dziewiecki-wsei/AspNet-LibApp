using LibApp.Domain.Models.Abstractions;
using System.Linq;

namespace LibApp.Data.Repository.Services
{
    public static class RepositoryHelper
    {
        public static IQueryable<T> FilterByName<T>(this IQueryable<T> query, string name) where T : EntityBase, IEntityName
        {
            if (string.IsNullOrWhiteSpace(name) == false)
                query = query.Where(x => x.Name.Contains(name));

            return query;
        }
    }
}
