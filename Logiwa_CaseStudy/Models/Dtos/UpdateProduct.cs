using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Logiwa_CaseStudy.Models
{
    public class UpdateProduct
    {

        public string Description { get; set; }

        [NotNull]
        [MaxLength(200)]
        public string Title { get; set; }

        public int StockQuantity { get; set; }

        [JsonIgnore]
        public virtual Category category { get; set; }

        public int CategoryID { get; set; }
    }
}
