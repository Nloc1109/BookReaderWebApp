using System;
using System.Collections.Generic;

namespace BookReaderWebApp.Models;

public partial class BookChapter
{
    public string Id { get; set; } = null!;

    public string BookId { get; set; } = null!;

    public string Title { get; set; } = null!;

    public string Slug { get; set; } = null!;

    public string? Content { get; set; }

    public int ChapterNumber { get; set; }

    public int? PageStart { get; set; }

    public int? PageEnd { get; set; }

    public int? WordCount { get; set; }

    public int? ReadingTimeMinutes { get; set; }

    public bool? IsFree { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual Book Book { get; set; } = null!;

    public virtual ICollection<UserBookmark> UserBookmarks { get; set; } = new List<UserBookmark>();

    public virtual ICollection<UserHighlight> UserHighlights { get; set; } = new List<UserHighlight>();

    public virtual ICollection<UserNote> UserNotes { get; set; } = new List<UserNote>();

    public virtual ICollection<UserReadingProgress> UserReadingProgresses { get; set; } = new List<UserReadingProgress>();
}
