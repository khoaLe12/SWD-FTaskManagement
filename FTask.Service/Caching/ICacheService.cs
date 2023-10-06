using System.Linq.Expressions;

namespace FTask.Service.Caching
{
    public interface ICacheService<T, TKey> where T : class
    {
        Task<T?> GetAsync(TKey id);
        Task SetAsync<T>(TKey id, T entity);
        Task RemoveAsync(TKey id);
    }
}
