using System;
using System.Collections.Generic;

namespace DorogiRossiiDEMO2ndSession.Models;

public partial class CrossContentEvent
{
    public int IdContent { get; set; }

    public int IdEvent { get; set; }

    public virtual Content IdContentNavigation { get; set; } = null!;

    public virtual Event IdEventNavigation { get; set; } = null!;
}
