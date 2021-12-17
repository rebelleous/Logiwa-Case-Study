namespace Logiwa_CaseStudy.Models
{
    public class CreateUpdateProductDto // Info's asked when Create/Update Product
    {
        public string Description { get; set; }
        public string Title { get; set; }
        public int StockQuantity { get; set; }
        public int CategoryID { get; set; }
    }
}
