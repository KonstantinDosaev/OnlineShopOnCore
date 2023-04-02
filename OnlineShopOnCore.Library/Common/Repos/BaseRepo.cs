using Microsoft.EntityFrameworkCore;
using OnlineShopOnCore.Library.Common.Interfaces;
using OnlineShopOnCore.Library.Data;

namespace OnlineShopOnCore.Library.Common.Repos
{
    public abstract class BaseRepo<T> : IRepo<T> where T : class, IIdentifiable, new()
    {
        public BaseRepo(OrdersDbContext context)
        {
            Context = context;
        }
        public OrdersDbContext Context { get; init; }

        protected DbSet<T> Table { get; set; }

        public async Task<Guid> AddAsync(T entity)
        {
            await Table.AddAsync(entity);
            await SaveChangesAsync();
            return entity.Id;
        }

        public async Task<IEnumerable<Guid>> AddRangeAsync(IEnumerable<T> entities)
        {
            await Table.AddRangeAsync(entities);
            await SaveChangesAsync();
            return new List<Guid>(entities.Select(e=>e.Id));
        }

        public async Task<int> RemoveAsync(Guid id)
        {
            var entity = await GetOneAsync(id);
            if (entity != null)
            {
                Context.Entry(entity).State = EntityState.Deleted;
                return await SaveChangesAsync();
            }
            return 0;
        }

        public async Task<int> RemoveRangeAsync(IEnumerable<Guid> ids)
        {
            int result = 0;
            foreach (var id in ids)
            {
                var affRows = await RemoveAsync(id);
                result += affRows;
            }

            return result;
        }

        public virtual async Task<IEnumerable<T>> GetAllAsync() => await Table.ToListAsync();

        public virtual async Task<T> GetOneAsync(Guid id) => await Task.Run(() => Table.FirstOrDefault(entity => entity.Id == id));

        public async Task<int> SaveAsync(T entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
            return await SaveChangesAsync();
        }

        internal async Task<int> SaveChangesAsync()
        {
            try
            {
                return await Context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                throw;
            }
            catch (DbUpdateException ex)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw;
            }

        }
    }
}
