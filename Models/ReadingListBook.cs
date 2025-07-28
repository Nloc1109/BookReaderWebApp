using System;
using System.Collections.Generic;

namespace BookReaderWebApp.Models;

public partial class ReadingListBook
{
    public string Id { get; set; } = null!;

    public string ReadingListId { get; set; } = null!;

    public string BookId { get; set; } = null!;

    public int? SortOrder { get; set; }

    public DateTime? AddedAt { get; set; }

    public virtual Book Book { get; set; } = null!;

    public virtual UserReadingList ReadingList { get; set; } = null!;
}
