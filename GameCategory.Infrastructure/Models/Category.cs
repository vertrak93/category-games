using System;
using System.Collections;
using System.Collections.Generic;

namespace GameCategory.Infrastructure.Models;

public partial class Category
{
    public int CategoryId { get; set; }

    public string NameCategory { get; set; } = null!;

    public string DescripcionCategory { get; set; } = null!;

    public BitArray Active { get; set; } = null!;

    public virtual ICollection<GameCategory> GameCategories { get; set; } = new List<GameCategory>();
}
