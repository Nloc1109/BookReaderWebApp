using System;
using System.Collections.Generic;

namespace BookReaderWebApp.Models;

public partial class UserReadingList
{
    public string Id { get; set; } = null!;

    public string UserId { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public bool? IsPublic { get; set; }

    public bool? IsDefault { get; set; }

    public int? SortOrder { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual ICollection<ReadingListBook> ReadingListBooks { get; set; } = new List<ReadingListBook>();

    public virtual User User { get; set; } = null!;
}
