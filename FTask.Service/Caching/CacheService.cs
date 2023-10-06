using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;

namespace FTask.Service.Caching
{
    public class CacheService<T, TKey> : ICacheService<T, TKey> where T : class
    {
        private readonly IDistributedCache _distributedCache;

        public CacheService(IDistributedCache distributedCache)
        {
            _distributedCache = distributedCache;
        }

        public async Task<T?> GetAsync(TKey id)
        {
            string cacheData = await _distributedCache.GetStringAsync(id.ToString());

            if (cacheData is null)
            {
                return null;
            }

            T? deserializedData = JsonConvert.DeserializeObject<T>(cacheData);
            return deserializedData;
        }

        public async Task RemoveAsync(TKey id)
        {
            await _distributedCache.RemoveAsync(id.ToString());
        }

        public async Task SetAsync<T>(TKey id, T entity)
        {
            string cacheData = JsonConvert.SerializeObject(entity);

            await _distributedCache.SetStringAsync(id.ToString(), cacheData);
        }
    }
}
