using System.ComponentModel.DataAnnotations;

namespace ISC_FormDataAnnotation.Models
{
    public class Product
    {
        [Display(Name = "Product Id")]
        [Required(ErrorMessage ="Enter Product Id")]
        public int ProductId { get; set; }

        [Display(Name = "Product Name")]
        [Required(ErrorMessage = "Enter Product Name")]
        [StringLength(100)]
        public string ProductName { get; set; }

        [Display(Name = "Product Qty")]
        [Required(ErrorMessage = "Enter Product Quantity")]
        [Range(0, 100, ErrorMessage = "Quantity cannot be more than 100")]
        public int Quantity { get; set; }

        [Display(Name = "Product Price")]
        [Required(ErrorMessage = "Enter Product Price")]
        [Range(0.01, 999999.99, ErrorMessage = "Price cannot be more than 999999.99 and less than 0.01")]
        public decimal Price { get; set; }
        
    }
}
