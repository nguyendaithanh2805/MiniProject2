using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class Menu
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public virtual ICollection<News> News { get; set; } = new List<News>();
}
