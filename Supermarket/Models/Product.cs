using System.ComponentModel.DataAnnotations;

namespace Supermarket.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public decimal Price { get; set; }

        // Foreign key to represent the category of the product
        [Required]
        public int CategoryId { get; set; }
        public Category? Category { get; set; }

        [Required]
        public int SupplierId { get; set; }
        public Supplier? Supplier { get; set; }
    }

}
