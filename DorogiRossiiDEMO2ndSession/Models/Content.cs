using System;
using System.Collections.Generic;

namespace DorogiRossiiDEMO2ndSession.Models;

public partial class Content
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public DateTime? ApprovalDate { get; set; }

    public DateTime? DateChange { get; set; }

    public int IdStatus { get; set; }

    public int IdType { get; set; }

    public string? Area { get; set; }

    public string? Author { get; set; }

    public virtual StatusContent IdStatusNavigation { get; set; } = null!;

    public virtual TypeContent IdTypeNavigation { get; set; } = null!;
}
