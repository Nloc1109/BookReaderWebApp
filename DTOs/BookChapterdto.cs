namespace BookReaderWebApp.DTOs
{
    public class BookChapterDto
    {
        public string Id { get; set; } = null!;
        public string Title { get; set; } = null!;
        public int ChapterNumber { get; set; }
        public string? Content { get; set; }
        public int? WordCount { get; set; }
        public int? ReadingTimeMinutes { get; set; }
        public DateTime? CreatedAt { get; set; }
    }
}