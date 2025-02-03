using System;
using System.Collections.Generic;

namespace DorogiRossiiDEMO2ndSession.Models;

public partial class WorkingCalendar
{
    public long Id { get; set; }

    public DateOnly ExceptionDate { get; set; }

    public sbyte IsWorkingDay { get; set; }
}
