using System;
using System.Collections.Generic;

namespace BookReaderWebApp.Models;

public partial class UserFavorite
{
    public string Id { get; set; } = null!;

    public string UserId { get; set; } = null!;

    public string BookId { get; set; } = null!;

    public DateTime? CreatedAt { get; set; }

    public virtual Book Book { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
