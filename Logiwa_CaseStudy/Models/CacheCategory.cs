using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Logiwa_CaseStudy.Models
{
    public class CacheCategory
    {
        public CacheCategory()
        {

        }

        public CacheCategory(string testName, int testMinStockQuantity)
        {
            Name = testName;
            MinStockQuantity = testMinStockQuantity;
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public int MinStockQuantity { get; set; }

        public class ResponseCacheCategory
        {
            public ResponseCacheCategory(double totalSeconds, List<Category> model)
            {
                Model = model;
                TotalSeconds = totalSeconds;
            }
            public double TotalSeconds { get; set; }

            public List<Category> Model { get; set; }
        }
    }
}
