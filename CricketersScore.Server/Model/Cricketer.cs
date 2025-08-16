using System;
using System.Collections.Generic;

namespace CricketersScore.Server.Model;

public partial class Cricketer
{
    public int Rank { get; set; }

    public string Name { get; set; } = null!;

    public int Score { get; set; }
}
