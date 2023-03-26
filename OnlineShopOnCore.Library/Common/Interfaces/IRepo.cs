
namespace OnlineShopOnCore.Library.Common.Interfaces
{
    public interface IRepo<T>
    {
        Task<Guid> AddAsync(T entity);

        Task<IEnumerable<Guid>> AddRangeAsync(IEnumerable<T> entities);

        Task<T> GetOneAsync(Guid id);

        Task<IEnumerable<T>> GetAllAsync();

        Task<int> RemoveAsync(Guid id);

        Task<int> RemoveRangeAsync(IEnumerable<Guid> ids);

        Task<int> SaveAsync(T entity);
    }
}
