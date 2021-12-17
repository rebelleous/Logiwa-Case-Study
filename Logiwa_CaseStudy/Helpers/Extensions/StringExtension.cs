using Newtonsoft.Json;

namespace Logiwa_CaseStudy.Extensions
{
    /// <summary>
    /// Redis'ten veriyi alırken json verisi olarak alacağımız için onu modele çevirmemiz gerektiğinden bu classı oluşturduk.
    /// </summary>
    public static class StringExtension
    {
        public static T ToObject<T>(this string value) where T : class
        {
            return string.IsNullOrEmpty(value) ? null : JsonConvert.DeserializeObject<T>(value);
        }
    }
}
