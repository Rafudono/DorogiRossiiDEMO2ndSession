using System;
using System.Collections.Generic;

namespace DorogiRossiiDEMO2ndSession.Models;

public partial class CrossResponsiblePerson
{
    public int IdEmployee { get; set; }

    public int IdEvent { get; set; }

    public virtual Employee IdEmployeeNavigation { get; set; } = null!;

    public virtual Event IdEventNavigation { get; set; } = null!;
}
