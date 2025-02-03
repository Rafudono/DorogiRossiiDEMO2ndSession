using System;
using System.Collections.Generic;

namespace DorogiRossiiDEMO2ndSession.Models;

public partial class StatusContent
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public virtual ICollection<Content> Contents { get; set; } = new List<Content>();
}
