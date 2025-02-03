using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DorogiRossiiDEMO2ndSession.Models
{
    public partial class Employee
    {
        public string FIO { get=>$"{LastName} {FirstName} {Patronymic}"; }
        public string Contacts { get=>$"{Phone} {Email}"; }
    }
}
