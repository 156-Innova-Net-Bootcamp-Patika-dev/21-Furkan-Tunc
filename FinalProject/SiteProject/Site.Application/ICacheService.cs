using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Site.Application
{
    public interface ICacheService<T>
    {
        Task<IReadOnlyList<T>> GetFromCache(string cacheKey);
    }
}
