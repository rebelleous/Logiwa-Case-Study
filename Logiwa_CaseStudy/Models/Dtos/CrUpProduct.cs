using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Logiwa_CaseStudy.Models
{
    public class CrUpProduct // Info's asked when Create/Update Product
    {
        public string Description { get; set; }
        public string Title { get; set; }
        public int StockQuantity { get; set; }
        public int CategoryID { get; set; }
    }
}
