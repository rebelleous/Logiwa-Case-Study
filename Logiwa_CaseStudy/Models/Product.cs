using System.Text.Json.Serialization;

namespace Logiwa_CaseStudy.Models
{
    public class Product
    {
        public int ID { get; set; }

        public string Description { get; set; }

        //[NotNull]
        //[MaxLength(200)] [İlk olarak annotation olarak validasyonları vermiştim]
        public string Title { get; set; }

        public int StockQuantity { get; set; }

        [JsonIgnore]
        public virtual Category category { get; set; }

        public int CategoryID { get; set; }
    }
}
