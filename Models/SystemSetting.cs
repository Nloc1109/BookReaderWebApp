using System;
using System.Collections.Generic;

namespace BookReaderWebApp.Models;

public partial class SystemSetting
{
    public string Id { get; set; } = null!;

    public string Key { get; set; } = null!;

    public string? Value { get; set; }

    public string? Description { get; set; }

    public string? DataType { get; set; }

    public bool? IsPublic { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
