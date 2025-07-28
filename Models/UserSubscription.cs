using System;
using System.Collections.Generic;

namespace BookReaderWebApp.Models;

public partial class UserSubscription
{
    public string Id { get; set; } = null!;

    public string UserId { get; set; } = null!;

    public string PlanType { get; set; } = null!;

    public string? Status { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime? EndDate { get; set; }

    public decimal? Price { get; set; }

    public string? Currency { get; set; }

    public string? PaymentMethod { get; set; }

    public bool? AutoRenew { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual User User { get; set; } = null!;
}
