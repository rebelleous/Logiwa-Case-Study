using Logiwa_CaseStudy.Extensions;
using Microsoft.Extensions.Configuration;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Logiwa_CaseStudy.Services
{
    public class RedisCacheService : ICacheService
    {
        private readonly ConnectionMultiplexer _client;

        public RedisCacheService(IConfiguration configuration)
        {
            var connectionString = configuration.GetSection("RedisConfiguration:ConnectionString")?.Value;

            ConfigurationOptions options = new ConfigurationOptions
            {
                EndPoints =
                {
                    connectionString // redis'e bağlanılacak olan url
                },
                AbortOnConnectFail = false, // redis'e bağlanamadığı durumda
                AsyncTimeout = 1000, // Redis'e async isteklerde 10 saniyeden geç yanıt verirse timeouta düşmesi için
                ConnectTimeout = 1000 // Redis'e normal isteklerde 10 saniyeden geç yanıt verirse timeouta düşmesi için
            };

            _client = ConnectionMultiplexer.Connect(options); // Redis'e bağlanmak için.
        }
        public T Get<T>(string key) where T : class
        {
            string value = _client.GetDatabase().StringGet(key);

            return value.ToObject<T>();
        }

        public string Get(string key)
        {
            return _client.GetDatabase().StringGet(key);
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

        public void Set(string key, string value)
        {
            _client.GetDatabase().StringSet(key, value);
        }

        public void Set<T>(string key, T value) where T : class
        {
            _client.GetDatabase().StringSet(key, value.ToJson());
        }

        public void Set(string key, object value, TimeSpan expiration)
        {
            _client.GetDatabase().StringSet(key, value.ToJson(), expiration);
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
