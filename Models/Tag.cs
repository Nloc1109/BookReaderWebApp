using System;
using System.Collections.Generic;

namespace BookReaderWebApp.Models;

public partial class Tag
{
    public string Id { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string Slug { get; set; } = null!;

    public string? Color { get; set; }

    public int? UsageCount { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual ICollection<BookTag> BookTags { get; set; } = new List<BookTag>();
}
