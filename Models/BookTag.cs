using System;
using System.Collections.Generic;

namespace BookReaderWebApp.Models;

public partial class BookTag
{
    public string Id { get; set; } = null!;

    public string BookId { get; set; } = null!;

    public string TagId { get; set; } = null!;

    public DateTime? CreatedAt { get; set; }

    public virtual Book Book { get; set; } = null!;

    public virtual Tag Tag { get; set; } = null!;
}
