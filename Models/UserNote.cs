using System;
using System.Collections.Generic;

namespace BookReaderWebApp.Models;

public partial class UserNote
{
    public string Id { get; set; } = null!;

    public string UserId { get; set; } = null!;

    public string BookId { get; set; } = null!;

    public string? ChapterId { get; set; }

    public string? Title { get; set; }

    public string Content { get; set; } = null!;

    public int? PageNumber { get; set; }

    public string? PositionData { get; set; }

    public string? Color { get; set; }

    public bool? IsPublic { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual Book Book { get; set; } = null!;

    public virtual BookChapter? Chapter { get; set; }

    public virtual User User { get; set; } = null!;
}
