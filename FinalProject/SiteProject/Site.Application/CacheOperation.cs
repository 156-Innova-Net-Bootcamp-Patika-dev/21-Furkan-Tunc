using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using Site.Application.Contracts.Persistence.Repositories.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Site.Application
{
    public class CacheOperation<T> //: ICacheService<T>
    {
        //private readonly IDistributedCache _distributedCache;
        //private readonly IRepositoryBase<T> _repositoryBase;
        //public CacheOperation(IDistributedCache distributedCache)
        //{
        //    _distributedCache = distributedCache;
        //}
        //public async Task<IReadOnlyList<T>> GetFromCache(string cacheKey)
        //{
        //    string json;
        //    IReadOnlyList<T> cacheList;

        //    var listFromCache = await _distributedCache.GetAsync(cacheKey);

        //    if (listFromCache != null)
        //    {
        //        json = Encoding.UTF8.GetString(listFromCache);
        //        return JsonConvert.DeserializeObject<IReadOnlyList<T>>(json);
        //    }
        //    else
        //    {
        //        cacheList = await _apartmentRepository.GetAllAsync();
        //        json = JsonConvert.SerializeObject(cacheList);
        //        listFromCache = Encoding.UTF8.GetBytes(json);
        //        var options = new DistributedCacheEntryOptions()
        //            .SetSlidingExpiration(TimeSpan.FromMinutes(1))
        //            .SetAbsoluteExpiration(DateTime.Now.AddHours(1));
        //        await _distributedCache.SetAsync(cacheKey, listFromCache, options);
        //        return cacheList;
        //    }
        //}
    }
}
