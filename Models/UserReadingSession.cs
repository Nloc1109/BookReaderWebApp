using System;
using System.Collections.Generic;

namespace BookReaderWebApp.Models;

public partial class UserReadingSession
{
    public string Id { get; set; } = null!;

    public string UserId { get; set; } = null!;

    public string BookId { get; set; } = null!;

    public DateTime StartTime { get; set; }

    public DateTime? EndTime { get; set; }

    public int? DurationMinutes { get; set; }

    public int? PagesRead { get; set; }

    public string? DeviceType { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual Book Book { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
