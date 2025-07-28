using System;
using System.Collections.Generic;

namespace BookReaderWebApp.Models;

public partial class UserFollow
{
    public string Id { get; set; } = null!;

    public string UserId { get; set; } = null!;

    public string AuthorId { get; set; } = null!;

    public DateTime? CreatedAt { get; set; }

    public virtual Author Author { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
