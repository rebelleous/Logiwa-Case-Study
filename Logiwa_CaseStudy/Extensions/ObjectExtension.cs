using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Logiwa_CaseStudy.Extensions
{
    /// <summary>
    /// Redis'e veriyi yazarken Json'a çevirip atacağımız için bu classı oluşturduk.
    /// </summary>
    public static class ObjectExtension
    {
        public static string ToJson(this object value)
        {
            return JsonConvert.SerializeObject(value);
        }
    }
}
