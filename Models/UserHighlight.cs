using System;
using System.Collections.Generic;

namespace BookReaderWebApp.Models;

public partial class UserHighlight
{
    public string Id { get; set; } = null!;

    public string UserId { get; set; } = null!;

    public string BookId { get; set; } = null!;

    public string? ChapterId { get; set; }

    public string SelectedText { get; set; } = null!;

    public string? StartPosition { get; set; }

    public string? EndPosition { get; set; }

    public string? Color { get; set; }

    public string? Note { get; set; }

    public bool? IsPublic { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual Book Book { get; set; } = null!;

    public virtual BookChapter? Chapter { get; set; }

    public virtual User User { get; set; } = null!;
}
