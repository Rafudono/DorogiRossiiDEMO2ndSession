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
        private Employee employeeOnPage;
        public bool CanEdit = false;
        public CheckEmplInfo(Employee empl)
        {
            EmployeeOnPage= empl;
            InitializeComponent();
            DataContext = this;
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
