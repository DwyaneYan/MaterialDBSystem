using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;

namespace HanGang.MaterialSystem.LinqExtensions
{
    public static class QueryableExtensions
    {
        public static Task<TEntity> GetAsync<TEntity, TKey>(this IQueryable<TEntity> query,
            TKey id)
            where TEntity : class, IEntity<TKey>
        {
            return query.FirstAsync(e => e.Id.Equals(id));
        }
    }
}