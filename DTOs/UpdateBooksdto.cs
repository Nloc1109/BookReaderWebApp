namespace BookReaderWebApp.DTOs
{
    public class UpdateBookDto
    {
        public string? Title { get; set; }
        public string? Subtitle { get; set; }
        public string? Description { get; set; }
        public string? Language { get; set; }
        public int? PageCount { get; set; }
        public DateTime? PublicationDate { get; set; }
        public string? CoverImageUrl { get; set; }
        public int? Price { get; set; }
        public bool? IsFree { get; set; }
        public string? Status { get; set; }
        
        public List<string>? AuthorIds { get; set; }
        public List<string>? CategoryIds { get; set; }
        public List<string>? TagNames { get; set; }
    }
}