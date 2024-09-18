namespace BuanaBike.Models
{
    public class Product
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public required string Url { get; set; }
        public required string ShortDescription { get; set; }
        public required int Price { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.Now;
    }
}
