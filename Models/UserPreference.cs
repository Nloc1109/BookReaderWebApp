using System;
using System.Collections.Generic;

namespace BookReaderWebApp.Models;

public partial class UserPreference
{
    public string Id { get; set; } = null!;

    public string UserId { get; set; } = null!;

    public string? Theme { get; set; }

    public string? FontFamily { get; set; }

    public int? FontSize { get; set; }

    public decimal? LineHeight { get; set; }

    public string? TextAlign { get; set; }

    public int? PageWidth { get; set; }

    public bool? AutoScroll { get; set; }

    public int? ScrollSpeed { get; set; }

    public string? ReadingMode { get; set; }

    public string? BackgroundColor { get; set; }

    public string? TextColor { get; set; }

    public string? LinkColor { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual User User { get; set; } = null!;
}
