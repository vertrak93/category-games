using System;
using System.Collections;
using System.Collections.Generic;

namespace GameCategory.Infrastructure.Models;

public partial class Game
{
    public int GameId { get; set; }

    public string NameGame { get; set; } = null!;

    public string Descripcption { get; set; } = null!;

    public BitArray Active { get; set; } = null!;

    public virtual ICollection<GameCategory> GameCategories { get; set; } = new List<GameCategory>();
}
