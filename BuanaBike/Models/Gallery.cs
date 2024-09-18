namespace BuanaBike.Models
{
    public class Gallery
    {
        public int Id { get; set; }
        public required string Url { get; set; }
        public required string Title { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.Now;
    }
}
