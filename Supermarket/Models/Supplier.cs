namespace Supermarket.Models
{
    public class Supplier
    {
        public int SupplierId { get; set; }
        public string CompanyName { get; set; }
        public string ContactPerson { get; set; }

        // Navigation property to represent products supplied by this supplier
        public virtual List<Product> SuppliedProducts { get; set; } = new List<Product>();
    }

}
