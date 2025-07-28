using System;
using System.Collections.Generic;

namespace BookReaderWebApp.Models;

public partial class Book
{
    public string Id { get; set; } = null!;

    public string Title { get; set; } = null!;

    public string Slug { get; set; } = null!;

    public string? Subtitle { get; set; }

    public string? Description { get; set; }

    public string? Isbn { get; set; }

    public string? Isbn13 { get; set; }

    public string? Language { get; set; }

    public string? OriginalLanguage { get; set; }

    public int? PageCount { get; set; }

    public int? WordCount { get; set; }

    public int? ReadingTimeMinutes { get; set; }

    public DateTime? PublicationDate { get; set; }

    public DateTime? OriginalPublicationDate { get; set; }

    public int? Edition { get; set; }

    public string? CoverImageUrl { get; set; }

    public string? CoverImageSmallUrl { get; set; }

    public string? CoverImageMediumUrl { get; set; }

    public string? CoverImageLargeUrl { get; set; }

    public string? FileUrl { get; set; }

    public string? FileType { get; set; }

    public int? FileSize { get; set; }

    public int? Price { get; set; }

    public bool? IsFree { get; set; }

    public bool? IsPremium { get; set; }

    public string? AgeRating { get; set; }

    public string? ContentWarning { get; set; }

    public string? Status { get; set; }

    public bool? Featured { get; set; }

    public bool? Trending { get; set; }

    public bool? EditorChoice { get; set; }

    public int? ViewCount { get; set; }

    public int? DownloadCount { get; set; }

    public int? AverageRating { get; set; }

    public int? RatingCount { get; set; }

    public string? SeoTitle { get; set; }

    public string? SeoDescription { get; set; }

    public string? SeoKeywords { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual ICollection<BookAuthor> BookAuthors { get; set; } = new List<BookAuthor>();

    public virtual ICollection<BookCategory> BookCategories { get; set; } = new List<BookCategory>();

    public virtual ICollection<BookChapter> BookChapters { get; set; } = new List<BookChapter>();

    public virtual ICollection<BookPublisher> BookPublishers { get; set; } = new List<BookPublisher>();

    public virtual ICollection<BookTag> BookTags { get; set; } = new List<BookTag>();

    public virtual ICollection<ReadingListBook> ReadingListBooks { get; set; } = new List<ReadingListBook>();

    public virtual ICollection<UserBookmark> UserBookmarks { get; set; } = new List<UserBookmark>();

    public virtual ICollection<UserFavorite> UserFavorites { get; set; } = new List<UserFavorite>();

    public virtual ICollection<UserHighlight> UserHighlights { get; set; } = new List<UserHighlight>();

    public virtual ICollection<UserNote> UserNotes { get; set; } = new List<UserNote>();

    public virtual ICollection<UserRating> UserRatings { get; set; } = new List<UserRating>();

    public virtual ICollection<UserReadingProgress> UserReadingProgresses { get; set; } = new List<UserReadingProgress>();

    public virtual ICollection<UserReadingSession> UserReadingSessions { get; set; } = new List<UserReadingSession>();
}
