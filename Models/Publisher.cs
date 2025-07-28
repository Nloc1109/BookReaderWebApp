using System;
using System.Collections.Generic;

namespace BookReaderWebApp.Models;

public partial class Publisher
{
    public string Id { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string Slug { get; set; } = null!;

    public string? Description { get; set; }

    public string? WebsiteUrl { get; set; }

    public string? LogoUrl { get; set; }

    public string? Address { get; set; }

    public string? Phone { get; set; }

    public string? Email { get; set; }

    public int? EstablishedYear { get; set; }

    public bool? IsActive { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual ICollection<BookPublisher> BookPublishers { get; set; } = new List<BookPublisher>();
}
