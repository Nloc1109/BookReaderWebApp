using System;
using System.Collections.Generic;

namespace BookReaderWebApp.Models;

public partial class BookAuthor
{
    public string Id { get; set; } = null!;

    public string BookId { get; set; } = null!;

    public string AuthorId { get; set; } = null!;

    public string? Role { get; set; }

    public int? SortOrder { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual Author Author { get; set; } = null!;

    public virtual Book Book { get; set; } = null!;
}
