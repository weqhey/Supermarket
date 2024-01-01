using System.ComponentModel.DataAnnotations;

namespace Supermarket.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        [Required]
        public string Name { get; set; }

        // Navigation property to represent products in this category
        public virtual List<Product> Products { get; set; } = new List<Product>();
    }

}
