namespace GoogleBooksApp.Models
{
    public class FavoriteBook
    {
        public int? FavoriteBookId { get; set; }
        public string? Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? Thumbnail { get; set; }
        public string? SmallThumbnail { get; set; }

        // Foreign key
        public int? UserId { get; set; }
        public User? User { get; set; }
    }
}
