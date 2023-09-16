using System;
using System.Collections;
using System.Collections.Generic;

namespace GameCategory.Infrastructure.Models;

public partial class GameCategory
{
    public int GameCategoryId { get; set; }

    public int CategoryId { get; set; }

    public int GameId { get; set; }

    public BitArray Active { get; set; } = null!;

    public virtual Category Category { get; set; } = null!;

    public virtual Game Game { get; set; } = null!;
}
