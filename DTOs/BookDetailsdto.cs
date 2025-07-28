namespace BookReaderWebApp.DTOs
{
    public class BookDetailDto : BookDto
    {
        public string? Isbn { get; set; }
        public string? Isbn13 { get; set; }
        public string? OriginalLanguage { get; set; }
        public int? WordCount { get; set; }
        public DateTime? OriginalPublicationDate { get; set; }
        public int? Edition { get; set; }
        public string? CoverImageSmallUrl { get; set; }
        public string? CoverImageMediumUrl { get; set; }
        public string? CoverImageLargeUrl { get; set; }
        public string? FileUrl { get; set; }
        public int? FileSize { get; set; }
        public string? AgeRating { get; set; }
        public string? ContentWarning { get; set; }
        public bool? Featured { get; set; }
        public bool? Trending { get; set; }
        public int? DownloadCount { get; set; }
        public string? SeoTitle { get; set; }
        public string? SeoDescription { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        
        // Include chapters for reading
        public List<BookChapterDto> Chapters { get; set; } = new();
        public List<PublisherDto> Publishers { get; set; } = new();
    }
}