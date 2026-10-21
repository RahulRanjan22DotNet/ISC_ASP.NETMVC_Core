using System.ComponentModel.DataAnnotations;

namespace ISC_WebAPIDemo_Student.Models
{
    public class Product
    {
        public int Id { get; set; }
        [Required]
        public string ProductName { get; set; }

        public string ProductDescription { get; set; }
        public string ProductCategory { get; set; }
        public float PurchasePrice { get; set; }
        public float SalePrice { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
