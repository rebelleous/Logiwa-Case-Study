using Logiwa_CaseStudy.Extensions;
using Microsoft.Extensions.Configuration;
using StackExchange.Redis;
using System;
using System.Threading.Tasks;

namespace Logiwa_CaseStudy.Services
{
    public class CacheService : ICacheService
    {
        private readonly ConnectionMultiplexer _client;

        public CacheService(IConfiguration configuration)
        {
            var connectionString = configuration.GetSection("RedisConfiguration:ConnectionString")?.Value;

            ConfigurationOptions options = new ConfigurationOptions
            {
                EndPoints =
                {
                    connectionString 
                },
                AbortOnConnectFail = false,
                AsyncTimeout = 1000, 
                ConnectTimeout = 1000 
            };

            _client = ConnectionMultiplexer.Connect(options); 
        }

        public async Task<T> GetAsync<T>(string key) where T : class
        {
            string value = await _client.GetDatabase().StringGetAsync(key);

            return value.ToObject<T>();
        }

        public void Remove(string key)
        {
            _client.GetDatabase().KeyDelete(key);
        }

        public Task SetAsync(string key, object value)
        {
            return _client.GetDatabase().StringSetAsync(key, value.ToJson());
        }

        public Task SetAsync(string key, object value, TimeSpan expiration)
        {
            return _client.GetDatabase().StringSetAsync(key, value.ToJson(), expiration);
        }
    }
}
