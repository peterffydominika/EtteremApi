using System;
using System.Collections.Generic;

namespace EtteremApi.Models;

public partial class Rendelestetel
{
    public int TetelId { get; set; }

    public int RendelesId { get; set; }

    public int TermekId { get; set; }

    public virtual Rendeles Rendeles { get; set; } = null!;

    public virtual Termek Termek { get; set; } = null!;
}
