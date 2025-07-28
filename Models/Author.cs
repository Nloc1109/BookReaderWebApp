using System;
using System.Collections.Generic;

namespace BookReaderWebApp.Models;

public partial class Author
{
    public string Id { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string Slug { get; set; } = null!;

    public string? Bio { get; set; }

    public DateTime? BirthDate { get; set; }

    public DateTime? DeathDate { get; set; }

    public string? Nationality { get; set; }

    public string? AvatarUrl { get; set; }

    public string? WebsiteUrl { get; set; }

    public bool? IsActive { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual ICollection<BookAuthor> BookAuthors { get; set; } = new List<BookAuthor>();

    public virtual ICollection<UserFollow> UserFollows { get; set; } = new List<UserFollow>();
}
