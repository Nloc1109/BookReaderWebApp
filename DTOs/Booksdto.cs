namespace BookReaderWebApp.DTOs
{
    public class BookDto
    {
        public string Id { get; set; } = null!;
        public string Title { get; set; } = null!;
        public string Slug { get; set; } = null!;
        public string? Subtitle { get; set; }
        public string? Description { get; set; }
        public string? Language { get; set; }
        public int? PageCount { get; set; }
        public int? ReadingTimeMinutes { get; set; }
        public DateTime? PublicationDate { get; set; }
        public string? CoverImageUrl { get; set; }
        public string? FileType { get; set; }
        public int? Price { get; set; }
        public bool? IsFree { get; set; }
        public string? Status { get; set; }
        public int? ViewCount { get; set; }
        public int? AverageRating { get; set; }
        public int? RatingCount { get; set; }
        
        // Simplified navigation properties
        public List<AuthorDto> Authors { get; set; } = new();
        public List<CategoryDto> Categories { get; set; } = new();
        public List<string> Tags { get; set; } = new();
    }
}