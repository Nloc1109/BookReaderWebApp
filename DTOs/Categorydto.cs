namespace BookReaderWebApp.DTOs
{
    public class CategoryDto
    {
        public string Id { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string Slug { get; set; } = null!;
        public string? Description { get; set; }
    }
}