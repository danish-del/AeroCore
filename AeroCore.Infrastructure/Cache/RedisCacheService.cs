using Microsoft.Extensions.Caching.Distributed;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AeroCore.Infrastructure.Cache
{
    public class RedisCacheService
    {
        private readonly IDistributedCache _cache;
        public RedisCacheService(IDistributedCache cache)
        {
            _cache = cache;
        }
        public async Task SetData(string key,string value)
        {
            await _cache.SetStringAsync(key, value);
        }
       public async Task<string?> GetData(string key)
        {
            return await _cache.GetStringAsync(key);
        }
    }
}
