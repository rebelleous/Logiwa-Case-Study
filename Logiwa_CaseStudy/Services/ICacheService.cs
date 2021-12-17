using System;
using System.Threading.Tasks;

namespace Logiwa_CaseStudy.Services
{

    /// Redise bağlanmak için kullanacağımız servisleri oluşturduk.

    public interface ICacheService
    {
        Task SetAsync(string key, object value);

        Task SetAsync(string key, object value, TimeSpan expiration);

        Task<T> GetAsync<T>(string key) where T : class;

        void Remove(string key);
    }
}
