using System;
using System.Collections.Generic;

namespace BookReaderWebApp.Models;

public partial class UserRating
{
    public string Id { get; set; } = null!;

    public string UserId { get; set; } = null!;

    public string BookId { get; set; } = null!;

    public int Rating { get; set; }

    public string? Review { get; set; }

    public bool? IsSpoiler { get; set; }

    public bool? IsPublic { get; set; }

    public int? HelpfulCount { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual Book Book { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
