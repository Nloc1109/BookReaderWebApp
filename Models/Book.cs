namespace BookReaderWebApp.Models
{
    public class Book
    {
        public int Id { get; set; } // Khóa chính
        public string Title { get; set; } = "";
        public string Author { get; set; } = "";
        public string Description { get; set; } = "";
    }
}
