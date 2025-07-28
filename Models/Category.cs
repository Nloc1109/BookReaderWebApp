using System;
using System.Collections.Generic;

namespace BookReaderWebApp.Models;

public partial class Category
{
    public string Id { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string Slug { get; set; } = null!;

    public string? Description { get; set; }

    public string? ParentId { get; set; }

    public string? IconUrl { get; set; }

    public string? ColorCode { get; set; }

    public int? SortOrder { get; set; }

    public bool? IsActive { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual ICollection<BookCategory> BookCategories { get; set; } = new List<BookCategory>();

    public virtual ICollection<Category> InverseParent { get; set; } = new List<Category>();

    public virtual Category? Parent { get; set; }
}
