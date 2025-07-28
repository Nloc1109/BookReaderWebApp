namespace BookReaderWebApp.DTOs
{
    public class CreateBookDto
    {
        public string Title { get; set; } = null!;
        public string? Subtitle { get; set; }
        public string? Description { get; set; }
        public string? Isbn { get; set; }
        public string? Isbn13 { get; set; }
        public string? Language { get; set; }
        public int? PageCount { get; set; }
        public DateTime? PublicationDate { get; set; }
        public string? CoverImageUrl { get; set; }
        public string? FileUrl { get; set; }
        public string? FileType { get; set; }
        public int? Price { get; set; }
        public bool IsFree { get; set; } = true;
        public string Status { get; set; } = "draft";
        
        // Author and category IDs
        public List<string> AuthorIds { get; set; } = new();
        public List<string> CategoryIds { get; set; } = new();
        public List<string> TagNames { get; set; } = new();
    }
}