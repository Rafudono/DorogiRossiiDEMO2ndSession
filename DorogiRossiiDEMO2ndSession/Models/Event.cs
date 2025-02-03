using System;
using System.Collections.Generic;

namespace DorogiRossiiDEMO2ndSession.Models;

public partial class Event
{
    public int Id { get; set; }

    public string? Title { get; set; }

    public int IdType { get; set; }

    public int IdStatus { get; set; }

    public DateTime? StartTime { get; set; }

    public DateTime? EndTime { get; set; }

    public string? Description { get; set; }

    public int? IdEmployee { get; set; }

    public int? IdDepartment { get; set; }

    public virtual Department? IdDepartmentNavigation { get; set; }

    public virtual Employee? IdEmployeeNavigation { get; set; }

    public virtual StatusEvent IdStatusNavigation { get; set; } = null!;

    public virtual TypeEvent IdTypeNavigation { get; set; } = null!;
}
