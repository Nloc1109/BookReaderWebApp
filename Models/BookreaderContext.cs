using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace BookReaderWebApp.Models;

public partial class BookreaderContext : DbContext
{
    public BookreaderContext()
    {
    }

    public BookreaderContext(DbContextOptions<BookreaderContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Author> Authors { get; set; }

    public virtual DbSet<Book> Books { get; set; }

    public virtual DbSet<BookAuthor> BookAuthors { get; set; }

    public virtual DbSet<BookCategory> BookCategories { get; set; }

    public virtual DbSet<BookChapter> BookChapters { get; set; }

    public virtual DbSet<BookPublisher> BookPublishers { get; set; }

    public virtual DbSet<BookTag> BookTags { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<EfmigrationsLock> EfmigrationsLocks { get; set; }

    public virtual DbSet<Notification> Notifications { get; set; }

    public virtual DbSet<Publisher> Publishers { get; set; }

    public virtual DbSet<ReadingListBook> ReadingListBooks { get; set; }

    public virtual DbSet<SystemSetting> SystemSettings { get; set; }

    public virtual DbSet<Tag> Tags { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserBookmark> UserBookmarks { get; set; }

    public virtual DbSet<UserFavorite> UserFavorites { get; set; }

    public virtual DbSet<UserFollow> UserFollows { get; set; }

    public virtual DbSet<UserHighlight> UserHighlights { get; set; }

    public virtual DbSet<UserNote> UserNotes { get; set; }

    public virtual DbSet<UserPreference> UserPreferences { get; set; }

    public virtual DbSet<UserRating> UserRatings { get; set; }

    public virtual DbSet<UserReadingGoal> UserReadingGoals { get; set; }

    public virtual DbSet<UserReadingList> UserReadingLists { get; set; }

    public virtual DbSet<UserReadingProgress> UserReadingProgresses { get; set; }

    public virtual DbSet<UserReadingSession> UserReadingSessions { get; set; }

    public virtual DbSet<UserSubscription> UserSubscriptions { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlite("Data Source=D:\\DuanCode\\BookReaderWebApp\\bookreader.db");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Author>(entity =>
        {
            entity.ToTable("authors");

            entity.HasIndex(e => e.Slug, "IX_authors_slug").IsUnique();

            entity.HasIndex(e => e.Name, "idx_authors_name");

            entity.HasIndex(e => e.Slug, "idx_authors_slug");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("lower(hex(randomblob(16)))")
                .HasColumnName("id");
            entity.Property(e => e.AvatarUrl).HasColumnName("avatar_url");
            entity.Property(e => e.Bio).HasColumnName("bio");
            entity.Property(e => e.BirthDate)
                .HasColumnType("DATE")
                .HasColumnName("birth_date");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("TIMESTAMP")
                .HasColumnName("created_at");
            entity.Property(e => e.DeathDate)
                .HasColumnType("DATE")
                .HasColumnName("death_date");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnType("BOOLEAN")
                .HasColumnName("is_active");
            entity.Property(e => e.Name).HasColumnName("name");
            entity.Property(e => e.Nationality).HasColumnName("nationality");
            entity.Property(e => e.Slug).HasColumnName("slug");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("TIMESTAMP")
                .HasColumnName("updated_at");
            entity.Property(e => e.WebsiteUrl).HasColumnName("website_url");
        });

        modelBuilder.Entity<Book>(entity =>
        {
            entity.ToTable("books");

            entity.HasIndex(e => e.Slug, "IX_books_slug").IsUnique();

            entity.HasIndex(e => e.AverageRating, "idx_books_average_rating");

            entity.HasIndex(e => e.CreatedAt, "idx_books_created_at");

            entity.HasIndex(e => e.Featured, "idx_books_featured");

            entity.HasIndex(e => e.PublicationDate, "idx_books_publication_date");

            entity.HasIndex(e => e.Slug, "idx_books_slug");

            entity.HasIndex(e => e.Status, "idx_books_status");

            entity.HasIndex(e => e.Trending, "idx_books_trending");

            entity.HasIndex(e => e.ViewCount, "idx_books_view_count");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("lower(hex(randomblob(16)))")
                .HasColumnName("id");
            entity.Property(e => e.AgeRating).HasColumnName("age_rating");
            entity.Property(e => e.AverageRating)
                .HasDefaultValue(0)
                .HasColumnType("DECIMAL(3,2)")
                .HasColumnName("average_rating");
            entity.Property(e => e.ContentWarning).HasColumnName("content_warning");
            entity.Property(e => e.CoverImageLargeUrl).HasColumnName("cover_image_large_url");
            entity.Property(e => e.CoverImageMediumUrl).HasColumnName("cover_image_medium_url");
            entity.Property(e => e.CoverImageSmallUrl).HasColumnName("cover_image_small_url");
            entity.Property(e => e.CoverImageUrl).HasColumnName("cover_image_url");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("TIMESTAMP")
                .HasColumnName("created_at");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.DownloadCount)
                .HasDefaultValue(0)
                .HasColumnName("download_count");
            entity.Property(e => e.Edition)
                .HasDefaultValue(1)
                .HasColumnName("edition");
            entity.Property(e => e.EditorChoice)
                .HasDefaultValue(false)
                .HasColumnType("BOOLEAN")
                .HasColumnName("editor_choice");
            entity.Property(e => e.Featured)
                .HasDefaultValue(false)
                .HasColumnType("BOOLEAN")
                .HasColumnName("featured");
            entity.Property(e => e.FileSize).HasColumnName("file_size");
            entity.Property(e => e.FileType).HasColumnName("file_type");
            entity.Property(e => e.FileUrl).HasColumnName("file_url");
            entity.Property(e => e.IsFree)
                .HasDefaultValue(true)
                .HasColumnType("BOOLEAN")
                .HasColumnName("is_free");
            entity.Property(e => e.IsPremium)
                .HasDefaultValue(false)
                .HasColumnType("BOOLEAN")
                .HasColumnName("is_premium");
            entity.Property(e => e.Isbn).HasColumnName("isbn");
            entity.Property(e => e.Isbn13).HasColumnName("isbn13");
            entity.Property(e => e.Language)
                .HasDefaultValue("vi")
                .HasColumnName("language");
            entity.Property(e => e.OriginalLanguage).HasColumnName("original_language");
            entity.Property(e => e.OriginalPublicationDate)
                .HasColumnType("DATE")
                .HasColumnName("original_publication_date");
            entity.Property(e => e.PageCount).HasColumnName("page_count");
            entity.Property(e => e.Price)
                .HasDefaultValue(0)
                .HasColumnType("DECIMAL(10,2)")
                .HasColumnName("price");
            entity.Property(e => e.PublicationDate)
                .HasColumnType("DATE")
                .HasColumnName("publication_date");
            entity.Property(e => e.RatingCount)
                .HasDefaultValue(0)
                .HasColumnName("rating_count");
            entity.Property(e => e.ReadingTimeMinutes).HasColumnName("reading_time_minutes");
            entity.Property(e => e.SeoDescription).HasColumnName("seo_description");
            entity.Property(e => e.SeoKeywords).HasColumnName("seo_keywords");
            entity.Property(e => e.SeoTitle).HasColumnName("seo_title");
            entity.Property(e => e.Slug).HasColumnName("slug");
            entity.Property(e => e.Status)
                .HasDefaultValue("published")
                .HasColumnName("status");
            entity.Property(e => e.Subtitle).HasColumnName("subtitle");
            entity.Property(e => e.Title).HasColumnName("title");
            entity.Property(e => e.Trending)
                .HasDefaultValue(false)
                .HasColumnType("BOOLEAN")
                .HasColumnName("trending");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("TIMESTAMP")
                .HasColumnName("updated_at");
            entity.Property(e => e.ViewCount)
                .HasDefaultValue(0)
                .HasColumnName("view_count");
            entity.Property(e => e.WordCount).HasColumnName("word_count");
        });

        modelBuilder.Entity<BookAuthor>(entity =>
        {
            entity.ToTable("book_authors");

            entity.HasIndex(e => new { e.BookId, e.AuthorId, e.Role }, "IX_book_authors_book_id_author_id_role").IsUnique();

            entity.Property(e => e.Id)
                .HasDefaultValueSql("lower(hex(randomblob(16)))")
                .HasColumnName("id");
            entity.Property(e => e.AuthorId).HasColumnName("author_id");
            entity.Property(e => e.BookId).HasColumnName("book_id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("TIMESTAMP")
                .HasColumnName("created_at");
            entity.Property(e => e.Role)
                .HasDefaultValue("author")
                .HasColumnName("role");
            entity.Property(e => e.SortOrder)
                .HasDefaultValue(0)
                .HasColumnName("sort_order");

            entity.HasOne(d => d.Author).WithMany(p => p.BookAuthors).HasForeignKey(d => d.AuthorId);

            entity.HasOne(d => d.Book).WithMany(p => p.BookAuthors).HasForeignKey(d => d.BookId);
        });

        modelBuilder.Entity<BookCategory>(entity =>
        {
            entity.ToTable("book_categories");

            entity.HasIndex(e => new { e.BookId, e.CategoryId }, "IX_book_categories_book_id_category_id").IsUnique();

            entity.Property(e => e.Id)
                .HasDefaultValueSql("lower(hex(randomblob(16)))")
                .HasColumnName("id");
            entity.Property(e => e.BookId).HasColumnName("book_id");
            entity.Property(e => e.CategoryId).HasColumnName("category_id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("TIMESTAMP")
                .HasColumnName("created_at");
            entity.Property(e => e.IsPrimary)
                .HasDefaultValue(false)
                .HasColumnType("BOOLEAN")
                .HasColumnName("is_primary");

            entity.HasOne(d => d.Book).WithMany(p => p.BookCategories).HasForeignKey(d => d.BookId);

            entity.HasOne(d => d.Category).WithMany(p => p.BookCategories).HasForeignKey(d => d.CategoryId);
        });

        modelBuilder.Entity<BookChapter>(entity =>
        {
            entity.ToTable("book_chapters");

            entity.HasIndex(e => new { e.BookId, e.ChapterNumber }, "IX_book_chapters_book_id_chapter_number").IsUnique();

            entity.HasIndex(e => new { e.BookId, e.Slug }, "IX_book_chapters_book_id_slug").IsUnique();

            entity.Property(e => e.Id)
                .HasDefaultValueSql("lower(hex(randomblob(16)))")
                .HasColumnName("id");
            entity.Property(e => e.BookId).HasColumnName("book_id");
            entity.Property(e => e.ChapterNumber).HasColumnName("chapter_number");
            entity.Property(e => e.Content).HasColumnName("content");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("TIMESTAMP")
                .HasColumnName("created_at");
            entity.Property(e => e.IsFree)
                .HasDefaultValue(true)
                .HasColumnType("BOOLEAN")
                .HasColumnName("is_free");
            entity.Property(e => e.PageEnd).HasColumnName("page_end");
            entity.Property(e => e.PageStart).HasColumnName("page_start");
            entity.Property(e => e.ReadingTimeMinutes).HasColumnName("reading_time_minutes");
            entity.Property(e => e.Slug).HasColumnName("slug");
            entity.Property(e => e.Title).HasColumnName("title");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("TIMESTAMP")
                .HasColumnName("updated_at");
            entity.Property(e => e.WordCount).HasColumnName("word_count");

            entity.HasOne(d => d.Book).WithMany(p => p.BookChapters).HasForeignKey(d => d.BookId);
        });

        modelBuilder.Entity<BookPublisher>(entity =>
        {
            entity.ToTable("book_publishers");

            entity.HasIndex(e => new { e.BookId, e.PublisherId, e.Role }, "IX_book_publishers_book_id_publisher_id_role").IsUnique();

            entity.Property(e => e.Id)
                .HasDefaultValueSql("lower(hex(randomblob(16)))")
                .HasColumnName("id");
            entity.Property(e => e.BookId).HasColumnName("book_id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("TIMESTAMP")
                .HasColumnName("created_at");
            entity.Property(e => e.PublisherId).HasColumnName("publisher_id");
            entity.Property(e => e.Role)
                .HasDefaultValue("publisher")
                .HasColumnName("role");

            entity.HasOne(d => d.Book).WithMany(p => p.BookPublishers).HasForeignKey(d => d.BookId);

            entity.HasOne(d => d.Publisher).WithMany(p => p.BookPublishers).HasForeignKey(d => d.PublisherId);
        });

        modelBuilder.Entity<BookTag>(entity =>
        {
            entity.ToTable("book_tags");

            entity.HasIndex(e => new { e.BookId, e.TagId }, "IX_book_tags_book_id_tag_id").IsUnique();

            entity.Property(e => e.Id)
                .HasDefaultValueSql("lower(hex(randomblob(16)))")
                .HasColumnName("id");
            entity.Property(e => e.BookId).HasColumnName("book_id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("TIMESTAMP")
                .HasColumnName("created_at");
            entity.Property(e => e.TagId).HasColumnName("tag_id");

            entity.HasOne(d => d.Book).WithMany(p => p.BookTags).HasForeignKey(d => d.BookId);

            entity.HasOne(d => d.Tag).WithMany(p => p.BookTags).HasForeignKey(d => d.TagId);
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.ToTable("categories");

            entity.HasIndex(e => e.Slug, "IX_categories_slug").IsUnique();

            entity.HasIndex(e => e.IsActive, "idx_categories_is_active");

            entity.HasIndex(e => e.ParentId, "idx_categories_parent_id");

            entity.HasIndex(e => e.Slug, "idx_categories_slug");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("lower(hex(randomblob(16)))")
                .HasColumnName("id");
            entity.Property(e => e.ColorCode).HasColumnName("color_code");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("TIMESTAMP")
                .HasColumnName("created_at");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.IconUrl).HasColumnName("icon_url");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnType("BOOLEAN")
                .HasColumnName("is_active");
            entity.Property(e => e.Name).HasColumnName("name");
            entity.Property(e => e.ParentId).HasColumnName("parent_id");
            entity.Property(e => e.Slug).HasColumnName("slug");
            entity.Property(e => e.SortOrder)
                .HasDefaultValue(0)
                .HasColumnName("sort_order");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("TIMESTAMP")
                .HasColumnName("updated_at");

            entity.HasOne(d => d.Parent).WithMany(p => p.InverseParent).HasForeignKey(d => d.ParentId);
        });

        modelBuilder.Entity<EfmigrationsLock>(entity =>
        {
            entity.ToTable("__EFMigrationsLock");

            entity.Property(e => e.Id).ValueGeneratedNever();
        });

        modelBuilder.Entity<Notification>(entity =>
        {
            entity.ToTable("notifications");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("lower(hex(randomblob(16)))")
                .HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("TIMESTAMP")
                .HasColumnName("created_at");
            entity.Property(e => e.Data).HasColumnName("data");
            entity.Property(e => e.IsRead)
                .HasDefaultValue(false)
                .HasColumnType("BOOLEAN")
                .HasColumnName("is_read");
            entity.Property(e => e.Message).HasColumnName("message");
            entity.Property(e => e.Title).HasColumnName("title");
            entity.Property(e => e.Type).HasColumnName("type");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.User).WithMany(p => p.Notifications).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<Publisher>(entity =>
        {
            entity.ToTable("publishers");

            entity.HasIndex(e => e.Slug, "IX_publishers_slug").IsUnique();

            entity.Property(e => e.Id)
                .HasDefaultValueSql("lower(hex(randomblob(16)))")
                .HasColumnName("id");
            entity.Property(e => e.Address).HasColumnName("address");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("TIMESTAMP")
                .HasColumnName("created_at");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.Email).HasColumnName("email");
            entity.Property(e => e.EstablishedYear).HasColumnName("established_year");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnType("BOOLEAN")
                .HasColumnName("is_active");
            entity.Property(e => e.LogoUrl).HasColumnName("logo_url");
            entity.Property(e => e.Name).HasColumnName("name");
            entity.Property(e => e.Phone).HasColumnName("phone");
            entity.Property(e => e.Slug).HasColumnName("slug");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("TIMESTAMP")
                .HasColumnName("updated_at");
            entity.Property(e => e.WebsiteUrl).HasColumnName("website_url");
        });

        modelBuilder.Entity<ReadingListBook>(entity =>
        {
            entity.ToTable("reading_list_books");

            entity.HasIndex(e => new { e.ReadingListId, e.BookId }, "IX_reading_list_books_reading_list_id_book_id").IsUnique();

            entity.Property(e => e.Id)
                .HasDefaultValueSql("lower(hex(randomblob(16)))")
                .HasColumnName("id");
            entity.Property(e => e.AddedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("TIMESTAMP")
                .HasColumnName("added_at");
            entity.Property(e => e.BookId).HasColumnName("book_id");
            entity.Property(e => e.ReadingListId).HasColumnName("reading_list_id");
            entity.Property(e => e.SortOrder)
                .HasDefaultValue(0)
                .HasColumnName("sort_order");

            entity.HasOne(d => d.Book).WithMany(p => p.ReadingListBooks).HasForeignKey(d => d.BookId);

            entity.HasOne(d => d.ReadingList).WithMany(p => p.ReadingListBooks).HasForeignKey(d => d.ReadingListId);
        });

        modelBuilder.Entity<SystemSetting>(entity =>
        {
            entity.ToTable("system_settings");

            entity.HasIndex(e => e.Key, "IX_system_settings_key").IsUnique();

            entity.Property(e => e.Id)
                .HasDefaultValueSql("lower(hex(randomblob(16)))")
                .HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("TIMESTAMP")
                .HasColumnName("created_at");
            entity.Property(e => e.DataType)
                .HasDefaultValue("string")
                .HasColumnName("data_type");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.IsPublic)
                .HasDefaultValue(false)
                .HasColumnType("BOOLEAN")
                .HasColumnName("is_public");
            entity.Property(e => e.Key).HasColumnName("key");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("TIMESTAMP")
                .HasColumnName("updated_at");
            entity.Property(e => e.Value).HasColumnName("value");
        });

        modelBuilder.Entity<Tag>(entity =>
        {
            entity.ToTable("tags");

            entity.HasIndex(e => e.Name, "IX_tags_name").IsUnique();

            entity.HasIndex(e => e.Slug, "IX_tags_slug").IsUnique();

            entity.Property(e => e.Id)
                .HasDefaultValueSql("lower(hex(randomblob(16)))")
                .HasColumnName("id");
            entity.Property(e => e.Color)
                .HasDefaultValue("#6B7280")
                .HasColumnName("color");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("TIMESTAMP")
                .HasColumnName("created_at");
            entity.Property(e => e.Name).HasColumnName("name");
            entity.Property(e => e.Slug).HasColumnName("slug");
            entity.Property(e => e.UsageCount)
                .HasDefaultValue(0)
                .HasColumnName("usage_count");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable("users");

            entity.HasIndex(e => e.Email, "IX_users_email").IsUnique();

            entity.HasIndex(e => e.Username, "IX_users_username").IsUnique();

            entity.HasIndex(e => e.CreatedAt, "idx_users_created_at");

            entity.HasIndex(e => e.Email, "idx_users_email");

            entity.HasIndex(e => e.IsActive, "idx_users_is_active");

            entity.HasIndex(e => e.Username, "idx_users_username");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("lower(hex(randomblob(16)))")
                .HasColumnName("id");
            entity.Property(e => e.AvatarUrl).HasColumnName("avatar_url");
            entity.Property(e => e.Bio).HasColumnName("bio");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("TIMESTAMP")
                .HasColumnName("created_at");
            entity.Property(e => e.DateOfBirth)
                .HasColumnType("DATE")
                .HasColumnName("date_of_birth");
            entity.Property(e => e.Email).HasColumnName("email");
            entity.Property(e => e.EmailVerified)
                .HasDefaultValue(false)
                .HasColumnType("BOOLEAN")
                .HasColumnName("email_verified");
            entity.Property(e => e.FirstName).HasColumnName("first_name");
            entity.Property(e => e.Gender).HasColumnName("gender");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnType("BOOLEAN")
                .HasColumnName("is_active");
            entity.Property(e => e.IsPremium)
                .HasDefaultValue(false)
                .HasColumnType("BOOLEAN")
                .HasColumnName("is_premium");
            entity.Property(e => e.LastLoginAt)
                .HasColumnType("TIMESTAMP")
                .HasColumnName("last_login_at");
            entity.Property(e => e.LastName).HasColumnName("last_name");
            entity.Property(e => e.PasswordHash).HasColumnName("password_hash");
            entity.Property(e => e.Phone).HasColumnName("phone");
            entity.Property(e => e.PreferredLanguage)
                .HasDefaultValue("vi")
                .HasColumnName("preferred_language");
            entity.Property(e => e.PremiumExpiresAt)
                .HasColumnType("TIMESTAMP")
                .HasColumnName("premium_expires_at");
            entity.Property(e => e.Timezone)
                .HasDefaultValue("Asia/Ho_Chi_Minh")
                .HasColumnName("timezone");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("TIMESTAMP")
                .HasColumnName("updated_at");
            entity.Property(e => e.Username).HasColumnName("username");
        });

        modelBuilder.Entity<UserBookmark>(entity =>
        {
            entity.ToTable("user_bookmarks");

            entity.HasIndex(e => e.CreatedAt, "idx_bookmarks_created_at");

            entity.HasIndex(e => new { e.UserId, e.BookId }, "idx_bookmarks_user_book");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("lower(hex(randomblob(16)))")
                .HasColumnName("id");
            entity.Property(e => e.BookId).HasColumnName("book_id");
            entity.Property(e => e.ChapterId).HasColumnName("chapter_id");
            entity.Property(e => e.Color)
                .HasDefaultValue("#FFD700")
                .HasColumnName("color");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("TIMESTAMP")
                .HasColumnName("created_at");
            entity.Property(e => e.IsPublic)
                .HasDefaultValue(false)
                .HasColumnType("BOOLEAN")
                .HasColumnName("is_public");
            entity.Property(e => e.Note).HasColumnName("note");
            entity.Property(e => e.PageNumber).HasColumnName("page_number");
            entity.Property(e => e.PositionData).HasColumnName("position_data");
            entity.Property(e => e.Title).HasColumnName("title");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("TIMESTAMP")
                .HasColumnName("updated_at");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.Book).WithMany(p => p.UserBookmarks).HasForeignKey(d => d.BookId);

            entity.HasOne(d => d.Chapter).WithMany(p => p.UserBookmarks).HasForeignKey(d => d.ChapterId);

            entity.HasOne(d => d.User).WithMany(p => p.UserBookmarks).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<UserFavorite>(entity =>
        {
            entity.ToTable("user_favorites");

            entity.HasIndex(e => new { e.UserId, e.BookId }, "IX_user_favorites_user_id_book_id").IsUnique();

            entity.Property(e => e.Id)
                .HasDefaultValueSql("lower(hex(randomblob(16)))")
                .HasColumnName("id");
            entity.Property(e => e.BookId).HasColumnName("book_id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("TIMESTAMP")
                .HasColumnName("created_at");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.Book).WithMany(p => p.UserFavorites).HasForeignKey(d => d.BookId);

            entity.HasOne(d => d.User).WithMany(p => p.UserFavorites).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<UserFollow>(entity =>
        {
            entity.ToTable("user_follows");

            entity.HasIndex(e => new { e.UserId, e.AuthorId }, "IX_user_follows_user_id_author_id").IsUnique();

            entity.Property(e => e.Id)
                .HasDefaultValueSql("lower(hex(randomblob(16)))")
                .HasColumnName("id");
            entity.Property(e => e.AuthorId).HasColumnName("author_id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("TIMESTAMP")
                .HasColumnName("created_at");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.Author).WithMany(p => p.UserFollows).HasForeignKey(d => d.AuthorId);

            entity.HasOne(d => d.User).WithMany(p => p.UserFollows).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<UserHighlight>(entity =>
        {
            entity.ToTable("user_highlights");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("lower(hex(randomblob(16)))")
                .HasColumnName("id");
            entity.Property(e => e.BookId).HasColumnName("book_id");
            entity.Property(e => e.ChapterId).HasColumnName("chapter_id");
            entity.Property(e => e.Color)
                .HasDefaultValue("#FFFF00")
                .HasColumnName("color");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("TIMESTAMP")
                .HasColumnName("created_at");
            entity.Property(e => e.EndPosition).HasColumnName("end_position");
            entity.Property(e => e.IsPublic)
                .HasDefaultValue(false)
                .HasColumnType("BOOLEAN")
                .HasColumnName("is_public");
            entity.Property(e => e.Note).HasColumnName("note");
            entity.Property(e => e.SelectedText).HasColumnName("selected_text");
            entity.Property(e => e.StartPosition).HasColumnName("start_position");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("TIMESTAMP")
                .HasColumnName("updated_at");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.Book).WithMany(p => p.UserHighlights).HasForeignKey(d => d.BookId);

            entity.HasOne(d => d.Chapter).WithMany(p => p.UserHighlights).HasForeignKey(d => d.ChapterId);

            entity.HasOne(d => d.User).WithMany(p => p.UserHighlights).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<UserNote>(entity =>
        {
            entity.ToTable("user_notes");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("lower(hex(randomblob(16)))")
                .HasColumnName("id");
            entity.Property(e => e.BookId).HasColumnName("book_id");
            entity.Property(e => e.ChapterId).HasColumnName("chapter_id");
            entity.Property(e => e.Color)
                .HasDefaultValue("#87CEEB")
                .HasColumnName("color");
            entity.Property(e => e.Content).HasColumnName("content");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("TIMESTAMP")
                .HasColumnName("created_at");
            entity.Property(e => e.IsPublic)
                .HasDefaultValue(false)
                .HasColumnType("BOOLEAN")
                .HasColumnName("is_public");
            entity.Property(e => e.PageNumber).HasColumnName("page_number");
            entity.Property(e => e.PositionData).HasColumnName("position_data");
            entity.Property(e => e.Title).HasColumnName("title");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("TIMESTAMP")
                .HasColumnName("updated_at");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.Book).WithMany(p => p.UserNotes).HasForeignKey(d => d.BookId);

            entity.HasOne(d => d.Chapter).WithMany(p => p.UserNotes).HasForeignKey(d => d.ChapterId);

            entity.HasOne(d => d.User).WithMany(p => p.UserNotes).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<UserPreference>(entity =>
        {
            entity.ToTable("user_preferences");

            entity.HasIndex(e => e.UserId, "IX_user_preferences_user_id").IsUnique();

            entity.Property(e => e.Id)
                .HasDefaultValueSql("lower(hex(randomblob(16)))")
                .HasColumnName("id");
            entity.Property(e => e.AutoScroll)
                .HasDefaultValue(false)
                .HasColumnType("BOOLEAN")
                .HasColumnName("auto_scroll");
            entity.Property(e => e.BackgroundColor)
                .HasDefaultValue("#FFFFFF")
                .HasColumnName("background_color");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("TIMESTAMP")
                .HasColumnName("created_at");
            entity.Property(e => e.FontFamily)
                .HasDefaultValue("Arial")
                .HasColumnName("font_family");
            entity.Property(e => e.FontSize)
                .HasDefaultValue(16)
                .HasColumnName("font_size");
            entity.Property(e => e.LineHeight)
                .HasDefaultValueSql("1.5")
                .HasColumnType("DECIMAL(3,1)")
                .HasColumnName("line_height");
            entity.Property(e => e.LinkColor)
                .HasDefaultValue("#0066CC")
                .HasColumnName("link_color");
            entity.Property(e => e.PageWidth)
                .HasDefaultValue(100)
                .HasColumnName("page_width");
            entity.Property(e => e.ReadingMode)
                .HasDefaultValue("paginated")
                .HasColumnName("reading_mode");
            entity.Property(e => e.ScrollSpeed)
                .HasDefaultValue(50)
                .HasColumnName("scroll_speed");
            entity.Property(e => e.TextAlign)
                .HasDefaultValue("left")
                .HasColumnName("text_align");
            entity.Property(e => e.TextColor)
                .HasDefaultValue("#000000")
                .HasColumnName("text_color");
            entity.Property(e => e.Theme)
                .HasDefaultValue("light")
                .HasColumnName("theme");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("TIMESTAMP")
                .HasColumnName("updated_at");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.User).WithOne(p => p.UserPreference).HasForeignKey<UserPreference>(d => d.UserId);
        });

        modelBuilder.Entity<UserRating>(entity =>
        {
            entity.ToTable("user_ratings");

            entity.HasIndex(e => new { e.UserId, e.BookId }, "IX_user_ratings_user_id_book_id").IsUnique();

            entity.HasIndex(e => e.BookId, "idx_ratings_book_id");

            entity.HasIndex(e => e.CreatedAt, "idx_ratings_created_at");

            entity.HasIndex(e => e.Rating, "idx_ratings_rating");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("lower(hex(randomblob(16)))")
                .HasColumnName("id");
            entity.Property(e => e.BookId).HasColumnName("book_id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("TIMESTAMP")
                .HasColumnName("created_at");
            entity.Property(e => e.HelpfulCount)
                .HasDefaultValue(0)
                .HasColumnName("helpful_count");
            entity.Property(e => e.IsPublic)
                .HasDefaultValue(true)
                .HasColumnType("BOOLEAN")
                .HasColumnName("is_public");
            entity.Property(e => e.IsSpoiler)
                .HasDefaultValue(false)
                .HasColumnType("BOOLEAN")
                .HasColumnName("is_spoiler");
            entity.Property(e => e.Rating).HasColumnName("rating");
            entity.Property(e => e.Review).HasColumnName("review");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("TIMESTAMP")
                .HasColumnName("updated_at");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.Book).WithMany(p => p.UserRatings).HasForeignKey(d => d.BookId);

            entity.HasOne(d => d.User).WithMany(p => p.UserRatings).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<UserReadingGoal>(entity =>
        {
            entity.ToTable("user_reading_goals");

            entity.HasIndex(e => new { e.UserId, e.Year }, "IX_user_reading_goals_user_id_year").IsUnique();

            entity.Property(e => e.Id)
                .HasDefaultValueSql("lower(hex(randomblob(16)))")
                .HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("TIMESTAMP")
                .HasColumnName("created_at");
            entity.Property(e => e.CurrentBooks)
                .HasDefaultValue(0)
                .HasColumnName("current_books");
            entity.Property(e => e.CurrentMinutes)
                .HasDefaultValue(0)
                .HasColumnName("current_minutes");
            entity.Property(e => e.CurrentPages)
                .HasDefaultValue(0)
                .HasColumnName("current_pages");
            entity.Property(e => e.TargetBooks)
                .HasDefaultValue(0)
                .HasColumnName("target_books");
            entity.Property(e => e.TargetMinutes)
                .HasDefaultValue(0)
                .HasColumnName("target_minutes");
            entity.Property(e => e.TargetPages)
                .HasDefaultValue(0)
                .HasColumnName("target_pages");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("TIMESTAMP")
                .HasColumnName("updated_at");
            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.Property(e => e.Year).HasColumnName("year");

            entity.HasOne(d => d.User).WithMany(p => p.UserReadingGoals).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<UserReadingList>(entity =>
        {
            entity.ToTable("user_reading_lists");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("lower(hex(randomblob(16)))")
                .HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("TIMESTAMP")
                .HasColumnName("created_at");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.IsDefault)
                .HasDefaultValue(false)
                .HasColumnType("BOOLEAN")
                .HasColumnName("is_default");
            entity.Property(e => e.IsPublic)
                .HasDefaultValue(false)
                .HasColumnType("BOOLEAN")
                .HasColumnName("is_public");
            entity.Property(e => e.Name).HasColumnName("name");
            entity.Property(e => e.SortOrder)
                .HasDefaultValue(0)
                .HasColumnName("sort_order");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("TIMESTAMP")
                .HasColumnName("updated_at");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.User).WithMany(p => p.UserReadingLists).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<UserReadingProgress>(entity =>
        {
            entity.ToTable("user_reading_progress");

            entity.HasIndex(e => new { e.UserId, e.BookId }, "IX_user_reading_progress_user_id_book_id").IsUnique();

            entity.HasIndex(e => e.LastReadAt, "idx_reading_progress_last_read");

            entity.HasIndex(e => e.Status, "idx_reading_progress_status");

            entity.HasIndex(e => new { e.UserId, e.BookId }, "idx_reading_progress_user_book");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("lower(hex(randomblob(16)))")
                .HasColumnName("id");
            entity.Property(e => e.BookId).HasColumnName("book_id");
            entity.Property(e => e.CompletedAt)
                .HasColumnType("TIMESTAMP")
                .HasColumnName("completed_at");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("TIMESTAMP")
                .HasColumnName("created_at");
            entity.Property(e => e.CurrentChapterId).HasColumnName("current_chapter_id");
            entity.Property(e => e.CurrentPage)
                .HasDefaultValue(0)
                .HasColumnName("current_page");
            entity.Property(e => e.LastReadAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("TIMESTAMP")
                .HasColumnName("last_read_at");
            entity.Property(e => e.LastReadPosition).HasColumnName("last_read_position");
            entity.Property(e => e.ProgressPercentage)
                .HasDefaultValueSql("0")
                .HasColumnType("DECIMAL(5,2)")
                .HasColumnName("progress_percentage");
            entity.Property(e => e.ReadingTimeMinutes)
                .HasDefaultValue(0)
                .HasColumnName("reading_time_minutes");
            entity.Property(e => e.StartedAt)
                .HasColumnType("TIMESTAMP")
                .HasColumnName("started_at");
            entity.Property(e => e.Status)
                .HasDefaultValue("reading")
                .HasColumnName("status");
            entity.Property(e => e.TotalPages)
                .HasDefaultValue(0)
                .HasColumnName("total_pages");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("TIMESTAMP")
                .HasColumnName("updated_at");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.Book).WithMany(p => p.UserReadingProgresses).HasForeignKey(d => d.BookId);

            entity.HasOne(d => d.CurrentChapter).WithMany(p => p.UserReadingProgresses).HasForeignKey(d => d.CurrentChapterId);

            entity.HasOne(d => d.User).WithMany(p => p.UserReadingProgresses).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<UserReadingSession>(entity =>
        {
            entity.ToTable("user_reading_sessions");

            entity.HasIndex(e => e.StartTime, "idx_reading_sessions_start_time");

            entity.HasIndex(e => e.UserId, "idx_reading_sessions_user_id");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("lower(hex(randomblob(16)))")
                .HasColumnName("id");
            entity.Property(e => e.BookId).HasColumnName("book_id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("TIMESTAMP")
                .HasColumnName("created_at");
            entity.Property(e => e.DeviceType).HasColumnName("device_type");
            entity.Property(e => e.DurationMinutes).HasColumnName("duration_minutes");
            entity.Property(e => e.EndTime)
                .HasColumnType("TIMESTAMP")
                .HasColumnName("end_time");
            entity.Property(e => e.PagesRead)
                .HasDefaultValue(0)
                .HasColumnName("pages_read");
            entity.Property(e => e.StartTime)
                .HasColumnType("TIMESTAMP")
                .HasColumnName("start_time");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.Book).WithMany(p => p.UserReadingSessions).HasForeignKey(d => d.BookId);

            entity.HasOne(d => d.User).WithMany(p => p.UserReadingSessions).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<UserSubscription>(entity =>
        {
            entity.ToTable("user_subscriptions");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("lower(hex(randomblob(16)))")
                .HasColumnName("id");
            entity.Property(e => e.AutoRenew)
                .HasDefaultValue(true)
                .HasColumnType("BOOLEAN")
                .HasColumnName("auto_renew");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("TIMESTAMP")
                .HasColumnName("created_at");
            entity.Property(e => e.Currency)
                .HasDefaultValue("VND")
                .HasColumnName("currency");
            entity.Property(e => e.EndDate)
                .HasColumnType("TIMESTAMP")
                .HasColumnName("end_date");
            entity.Property(e => e.PaymentMethod).HasColumnName("payment_method");
            entity.Property(e => e.PlanType).HasColumnName("plan_type");
            entity.Property(e => e.Price)
                .HasColumnType("DECIMAL(10,2)")
                .HasColumnName("price");
            entity.Property(e => e.StartDate)
                .HasColumnType("TIMESTAMP")
                .HasColumnName("start_date");
            entity.Property(e => e.Status)
                .HasDefaultValue("active")
                .HasColumnName("status");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("TIMESTAMP")
                .HasColumnName("updated_at");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.User).WithMany(p => p.UserSubscriptions).HasForeignKey(d => d.UserId);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
