using GenericImplementation.Api.DbContexts;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;

namespace GenericImplementation.Api.Services
{
    public class GenericDataService<T> where T : class
    {
        private readonly GenericDbContext _dbContext;
        public GenericDataService(GenericDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<T?> AddAsync(T item)
        {
            await _dbContext.Set<T>().AddAsync(item);
            await _dbContext.SaveChangesAsync();
            return item;
        }

        public async Task<T?> UpdateAsync(int key, T updated)
        {
            if (updated == null)
            {
                return null;
            }

            T? existing = await _dbContext.Set<T>().FindAsync(key);

            if (existing != null)
            {
                _dbContext.Entry(existing).CurrentValues.SetValues(updated);
                await _dbContext.SaveChangesAsync();
            }

            return existing;
        }

        public async Task<T?> PatchUpdateAsync(int key, JsonPatchDocument<T> entity)
        {

            T? entityToPatch = await _dbContext.Set<T>().FindAsync(key);

            if (entityToPatch == null)
            {
                return null;
            }

            entity.ApplyTo(entityToPatch);
            await _dbContext.SaveChangesAsync();

            return entityToPatch;
        }

        public IQueryable<T> GetAll()
        {
            var dbContextSet = _dbContext.Set<T>().AsNoTracking();
            return dbContextSet;
        }

        public async Task<T?> GetById(int key)
        {
            T? existing = await _dbContext.Set<T>().FindAsync(key);

            return existing;
        }

        public async Task DeleteAsync(int key)
        {
            T? existing = await _dbContext.Set<T>().FindAsync(key);

            if (existing != null)
            {
                _dbContext.Set<T>().Remove(existing);

                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
