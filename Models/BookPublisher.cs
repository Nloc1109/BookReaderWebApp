using System;
using System.Collections.Generic;

namespace BookReaderWebApp.Models;

public partial class BookPublisher
{
    public string Id { get; set; } = null!;

    public string BookId { get; set; } = null!;

    public string PublisherId { get; set; } = null!;

    public string? Role { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual Book Book { get; set; } = null!;

    public virtual Publisher Publisher { get; set; } = null!;
}
