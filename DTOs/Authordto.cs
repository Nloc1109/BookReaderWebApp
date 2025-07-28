namespace BookReaderWebApp.DTOs
{
    public class AuthorDto
    {
        public string Id { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string? Bio { get; set; }
        public string? ImageUrl { get; set; }
    }
}