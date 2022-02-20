using LibApp.Data.Data;
using LibApp.Data.Repository.Interfaces;
using LibApp.Domain.Models.Abstractions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibApp.Data.Repository.Services
{
    internal abstract class Repository<T> : IRepository<T> where T : EntityBase
    {
        protected readonly ApplicationDbContext context;

        public Repository(ApplicationDbContext context)
        {
            this.context = context;
        }

        protected async Task UpdateEntityAsync(T entity)
        {
            context.Set<T>().Update(entity);
            await context.SaveChangesAsync();
        }

        public virtual async Task<bool> DeleteByIdAsync(int id)
        {
            var entity = await GetByIdAsync(id);

            if (entity is null)
                return false;

            context.Remove(entity);
            await context.SaveChangesAsync();

            return true;
        }

        public virtual async Task AddRangeAsync(IList<T> entities)
        {
            await context.AddRangeAsync(entities);
            await context.SaveChangesAsync();
        }

        public virtual async Task<int> AddAsync(T entity)
        {
            await context.AddAsync(entity);
            await context.SaveChangesAsync();

            if (entity is IEntityId entityId)
                return entityId.Id;
            else if (entity is IEntityTinyId entityTinyId)
                return entityTinyId.Id;
            else
                throw new InvalidOperationException();
        }

        public virtual async Task<T> GetByIdAsync(int id, bool noTracking = false)
        {
            var query = context.Set<T>().AsQueryable();
            
            if (noTracking)
                query = query.AsNoTracking();

            if (typeof(IEntityId).IsAssignableFrom(typeof(T)))
                return await query.SingleOrDefaultAsync(x => (x as IEntityId).Id == id);
            else if (typeof(IEntityTinyId).IsAssignableFrom(typeof(T)))
                return await query.SingleOrDefaultAsync(x => (x as IEntityTinyId).Id == (byte)id);
            else
                throw new InvalidOperationException();
        }

        public virtual async Task<IList<T>> GetAllAsync()
            => await GetAllQuery<T>().ToListAsync();

        protected IQueryable<M> GetAllQuery<M>() where M : T
            => context.Set<M>().AsQueryable();

        protected IQueryable<M> GetAllFilteredByNameQuery<M>(string name) where M : T, IEntityName
            => GetAllQuery<M>().FilterByName(name);
        
        public abstract Task<bool> UpdateAsync(T entity);
    }
}
