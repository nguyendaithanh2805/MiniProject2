using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class News
{
    public int Id { get; set; }

    public int MenuId { get; set; }

    public string Title { get; set; } = null!;

    public string? Content { get; set; }

    public virtual Menu Menu { get; set; } = null!;
}
