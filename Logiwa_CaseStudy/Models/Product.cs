using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace Logiwa_CaseStudy.Models
{
    public class Product
    {
        public int ID { get; set; }

        public string Description { get; set; }

        [NotNull]
        [MaxLength(200)]
        public string Title { get; set; }

        public int StockQuantity { get; set; }

        [Required]
        public virtual Category category { get; set; }

        public int CategoryID { get; set; }
    }
}
