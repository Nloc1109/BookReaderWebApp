using System;
using System.Collections.Generic;

namespace BookReaderWebApp.Models;

public partial class UserReadingProgress
{
    public string Id { get; set; } = null!;

    public string UserId { get; set; } = null!;

    public string BookId { get; set; } = null!;

    public int? CurrentPage { get; set; }

    public int? TotalPages { get; set; }

    public string? CurrentChapterId { get; set; }

    public decimal? ProgressPercentage { get; set; }

    public int? ReadingTimeMinutes { get; set; }

    public string? LastReadPosition { get; set; }

    public string? Status { get; set; }

    public DateTime? StartedAt { get; set; }

    public DateTime? CompletedAt { get; set; }

    public DateTime? LastReadAt { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual Book Book { get; set; } = null!;

    public virtual BookChapter? CurrentChapter { get; set; }

    public virtual User User { get; set; } = null!;
}
