namespace BuanaBike.Models
{
    public class ProductRecord
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
        public int TotalPrice { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.Now;
    }
}
