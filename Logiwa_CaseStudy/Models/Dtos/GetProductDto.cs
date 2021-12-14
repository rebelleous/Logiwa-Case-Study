using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Logiwa_CaseStudy.Models.Dtos
{
    public class GetProductDto
    {
        public int ID { get; set; }
        public string Description { get; set; }
        public string Title { get; set; }

        public int StockQuantity { get; set; }
        public string categoryName { get; set; }
        public int CategoryID { get; set; }
    }
}
