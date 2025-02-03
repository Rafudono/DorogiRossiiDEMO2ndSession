using System;
using System.Collections.Generic;

namespace DorogiRossiiDEMO2ndSession.Models;

public class Department
{
    public int Id { get; set; }

    public string Title { get; set; }

    public string? Description { get; set; }

    public int? IdMainDep { get; set; }

    public int? IdDirector { get; set; }

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();

    public virtual ICollection<Event> Events { get; set; } = new List<Event>();

    public virtual Employee? IdDirectorNavigation { get; set; }

    public virtual Department? IdMainDepNavigation { get; set; }

    public virtual ICollection<Department> InverseIdMainDepNavigation { get; set; } = new List<Department>();
}
