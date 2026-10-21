using System.ComponentModel.DataAnnotations;

namespace ISC_WebAPIDemo_Student.Models
{
    public class ProductDTO2
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public string ProductCategory { get; set; }
        public float SalePrice { get; set; }
    }
}
