using System;
using System.Collections.Generic;

namespace BookReaderWebApp.Models;

public partial class UserReadingGoal
{
    public string Id { get; set; } = null!;

    public string UserId { get; set; } = null!;

    public int Year { get; set; }

    public int? TargetBooks { get; set; }

    public int? TargetPages { get; set; }

    public int? TargetMinutes { get; set; }

    public int? CurrentBooks { get; set; }

    public int? CurrentPages { get; set; }

    public int? CurrentMinutes { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual User User { get; set; } = null!;
}
