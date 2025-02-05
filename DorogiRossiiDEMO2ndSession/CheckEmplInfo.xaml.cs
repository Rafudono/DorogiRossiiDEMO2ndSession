using DorogiRossiiDEMO2ndSession.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace DorogiRossiiDEMO2ndSession
{
    /// <summary>
    /// Логика взаимодействия для CheckEmplInfo.xaml
    /// </summary>
    public partial class CheckEmplInfo : Window, INotifyPropertyChanged
    {
        public List<Event> EmployeeEvents { get => employeeEvents; set
            {
                employeeEvents = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(EmployeeEvents)));
            }
        }
        public List<Employee> EmployeesFromSameDep { get => employeesFromSameDep; set
            {
                employeesFromSameDep = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(EmployeesFromSameDep)));
            }
        }
        public Employee SelectedHelper { get => selectedHelper; set
            {
                selectedHelper = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SelectedHelper)));
            }
        }
        public Employee SelectedBoss { get => selectedBoss; set

            {
                selectedBoss = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SelectedBoss)));
            }
        }
        private Employee employeeOnPage;
        public bool CanEdit = false;
        private Employee selectedHelper;
        private Employee selectedBoss;
        private List<Employee> employeesFromSameDep = new List<Employee>();
        private List<Event> employeeEvents;

        public CheckEmplInfo(Employee empl)
        {
            EmployeeOnPage= empl;
            InitializeComponent();
            FillCollection();
            DataContext = this;
        }

        private async void FillCollection()
        {
            List<Employee> allEmpl=await DATA.GetInstance().GetEmployees();
            EmployeesFromSameDep = allEmpl.Where(s=>s.IdDepartment==EmployeeOnPage.IdDepartment).ToList();
            List<Event> allEvents = await DATA.GetInstance().GetEvents();
            List<CrossResponsiblePerson> crossResponsiblePeople= new List<CrossResponsiblePerson>(); //получить все кросы
            EmployeeEvents =allEvents.Where(s=>s.IdEmployee==EmployeeOnPage.Id||s.).ToList(); //сравнить idevent с idизкросса и idempl с idизкросса
        }

        public Employee EmployeeOnPage
        {
            get => employeeOnPage;
            set
            {
                employeeOnPage = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(EmployeeOnPage)));
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
    }
}
