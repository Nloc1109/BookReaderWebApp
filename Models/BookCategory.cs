using System;
using System.Collections.Generic;

namespace BookReaderWebApp.Models;

public partial class BookCategory
{
    public string Id { get; set; } = null!;

    public string BookId { get; set; } = null!;

    public string CategoryId { get; set; } = null!;

    public bool? IsPrimary { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual Book Book { get; set; } = null!;

    public virtual Category Category { get; set; } = null!;
}
