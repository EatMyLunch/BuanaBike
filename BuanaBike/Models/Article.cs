namespace BuanaBike.Models
{
    public class Article
    {
        public int Id { get; set; }
        public required string Url { get; set; }
        public required string Header { get; set; }
        public required string Description { get; set; }
        public required string ShortDescription { get; set; }
        public DateTime PublishDate { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.Now;
    }
}
