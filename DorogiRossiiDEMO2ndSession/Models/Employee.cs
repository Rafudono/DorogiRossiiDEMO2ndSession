using System;
using System.Collections.Generic;

namespace DorogiRossiiDEMO2ndSession.Models;

public partial class Employee
{
    public int Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string? LastName { get; set; }

    public string? Patronymic { get; set; }

    public int IdDepartment { get; set; }

    public int IdRole { get; set; }

    public string? Phone { get; set; }

    public int IdOffice { get; set; }

    public string? Email { get; set; }

    public string? Description { get; set; }

    public string? OfficePhone { get; set; }

    public DateTime? Birthday { get; set; }

    public int? IdDirector { get; set; }

    public int? IdHelper { get; set; }

    public virtual ICollection<Department> Departments { get; set; } = new List<Department>();

    public virtual ICollection<Event> Events { get; set; } = new List<Event>();

    public virtual Department IdDepartmentNavigation { get; set; } = null!;

    public virtual Employee? IdDirectorNavigation { get; set; }

    public virtual Employee? IdHelperNavigation { get; set; }

    public virtual Office IdOfficeNavigation { get; set; } = null!;

    public virtual Role IdRoleNavigation { get; set; } = null!;

    public virtual ICollection<Employee> InverseIdDirectorNavigation { get; set; } = new List<Employee>();

    public virtual ICollection<Employee> InverseIdHelperNavigation { get; set; } = new List<Employee>();
}
