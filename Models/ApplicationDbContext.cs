using Microsoft.EntityFrameworkCore;

namespace BookReaderWebApp.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // Core entities
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        
        // Book relationships
        public DbSet<BookAuthor> BookAuthors { get; set; }
        public DbSet<BookCategory> BookCategories { get; set; }
        public DbSet<BookTag> BookTags { get; set; }
        public DbSet<BookPublisher> BookPublishers { get; set; }
        public DbSet<BookChapter> BookChapters { get; set; }
        
        // User-related entities (assuming you have User model)
        // public DbSet<User> Users { get; set; } // Uncomment if you have User model
        public DbSet<UserBookmark> UserBookmarks { get; set; }
        public DbSet<UserFavorite> UserFavorites { get; set; }
        public DbSet<UserHighlight> UserHighlights { get; set; }
        public DbSet<UserNote> UserNotes { get; set; }
        public DbSet<UserRating> UserRatings { get; set; }
        public DbSet<UserReadingProgress> UserReadingProgresses { get; set; }
        public DbSet<UserReadingSession> UserReadingSessions { get; set; }
        public DbSet<UserPreference> UserPreferences { get; set; }
        public DbSet<UserFollow> UserFollows { get; set; }
        
        // Reading lists
        public DbSet<ReadingListBook> ReadingListBooks { get; set; }
        
        // System
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<SystemSetting> SystemSettings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            // Configure relationships and constraints here if needed
            // Example:
            // modelBuilder.Entity<BookAuthor>()
            //     .HasKey(ba => new { ba.BookId, ba.AuthorId });
            
            // Configure decimal precision for Price
            modelBuilder.Entity<Book>()
                .Property(b => b.Price)
                .HasColumnType("decimal(18,2)");
                
            // Configure string lengths to avoid EF warnings
            modelBuilder.Entity<Book>()
                .Property(b => b.Title)
                .HasMaxLength(500);
                
            modelBuilder.Entity<Book>()
                .Property(b => b.Slug)
                .HasMaxLength(500);
        }
    }
}