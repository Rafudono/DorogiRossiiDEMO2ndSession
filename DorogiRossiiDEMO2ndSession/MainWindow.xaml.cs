using DorogiRossiiDEMO2ndSession.Models;
using System;
using System.ComponentModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DorogiRossiiDEMO2ndSession
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public List<Employee> Employees { get; set; }
        public List<Employee> CurrentDepartmentEmployees
        {
            get => currentDepartmentEmployees;
            set
            {
                currentDepartmentEmployees = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CurrentDepartmentEmployees)));
            }
        }
        public Employee SelectedEmpl { get => selectedEmpl; 
            set
            {
                selectedEmpl = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SelectedEmpl)));

            }
        }

        public List<Department> Departments { get; set; } = new List<Department>();    //заполнить методом гет из DATA
        private Dictionary<int, List<Button>> buttonsLevel = new Dictionary<int, List<Button>>();
        private List<Employee> currentDepartmentEmployees = new List<Employee>();
        private Employee selectedEmpl;

        public event PropertyChangedEventHandler? PropertyChanged;

        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
            
            Task.Run(async () =>
            {
                await FillCollections();
                await DrawDiagramm();

            });
        }

        public async Task FillCollections()
        {
            Departments = await DATA.GetInstance().GetDepartments();
            Employees = await DATA.GetInstance().GetEmployees();
        }
        public async Task DrawDiagramm()
        {
            //НИЖЕ ГЕНИАЛЬНЫЙ МЕТОД БЕЗ ЭТИХ ВАШИХ ВСЕХ РЕКУРСИЙ И ВОТ ЭТОГО ВОТ ВСЕГО
            //(к сожалению, он работает только потому, что я знаю уровень вложенности((()
            List<Department> firstlevel = Departments.Where(s => s.IdMainDepNavigation is null).ToList();
            /*     List<Department> secondlevel = new List<Department>();
            //    List<Department> thirdlevel = new List<Department>();

            //    List<Department> notmain = new List<Department>();
            //    foreach (Department department in Departments)
            //    {
            //        if(department.IdMainDep is null || department.IdMainDep==0)
            //        {
            //            firstlevel.Add(department);
            //        }
            //        else
            //        {
            //            notmain.Add(department);
            //        }
            //    }
            //    foreach (Department department in notmain)
            //    {
            //        var upDep= Departments.FirstOrDefault(s => s.Id == department.IdMainDep);
            //        if(upDep.IdMainDep is null || upDep.IdMainDep == 0)
            //        {
            //            secondlevel.Add(department);
            //        }
            //        else
            //        {
            //            thirdlevel.Add(department);
            //        }
            //    }

            //    Dispatcher.Invoke(() =>
            //    {
            //        double left1 = 0;
            //        foreach (Department department in firstlevel)
            //        {
            //            Button button = new Button();
            //            button.Content = department.Title;
            //            diagram.Children.Add(button);

            //            Canvas.SetLeft(button, left1);
            //            left1 += department.Title.Length*7+30;  //actualwidth можно использовать, если подождать пока кнопки отрисуются
            //            //например кнопки добавить в списки, а потом для каждой кнопки в списке выставить топ и лефт
            //        }
            //       double left2 = 0;
            //        double max = 0;
            //        foreach (Department department in secondlevel)
            //        {
            //            Button button = new Button();
            //            button.Content = department.Title;
            //            diagram.Children.Add(button);
            //            Canvas.SetTop(button, 50);
            //            Canvas.SetLeft(button, left2);
            //            if (department == secondlevel.Last())
            //                max = left2-30;
            //            left2 += department.Title.Length * 7 + 30;
            //        }
            //        diagram.Width= max;

            //        double left3 = 0;
            //        foreach (Department department in thirdlevel)
            //        {
            //            Button button = new Button();
            //            button.Content = department.Title;
            //            diagram.Children.Add(button);
            //            Canvas.SetTop(button, 100);
            //            Canvas.SetLeft(button, left3);
            //            left3 += department.Title.Length * 7 + 30;
            //        }

            //    });
            //    await Task.CompletedTask;*/
            GenerateButtons(firstlevel, 1);
            await SetButtonPositions();
            await PaintLines();
            await Task.CompletedTask;

        }


        public void GenerateButtons(List<Department> departments, int level)
        {
            Dispatcher.Invoke(() =>
            {
                if (buttonsLevel.Count < level)
                {
                    buttonsLevel[level] = new List<Button>();
                }
                foreach (Department department in departments)
                {
                    Button button = new Button();
                    button.Tag = department;
                    button.Content = department.Title;
                    button.Click += GetEmployees;
                    diagram.Children.Add(button);
                    buttonsLevel[level].Add(button);
                    if (department.InverseIdMainDepNavigation.Count > 0)
                        GenerateButtons(department.InverseIdMainDepNavigation.ToList(), level + 1);
                }
            });
        }

        private void GetEmployees(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            Department department = button.Tag as Department;
            
            EmployeesFromDeps(department);
            var n = CurrentDepartmentEmployees;
            CurrentDepartmentEmployees = null;
            CurrentDepartmentEmployees = new List<Employee>(n);
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CurrentDepartmentEmployees)));
        }

        private void EmployeesFromDeps(Department? department)
        {
            CurrentDepartmentEmployees.AddRange(Employees.Where(s => s.IdDepartment == department.Id).ToList());
            if(department.InverseIdMainDepNavigation.Count!=0)
            {
                foreach (var d in department.InverseIdMainDepNavigation)
                    EmployeesFromDeps(d);
            }
        }

        public async Task SetButtonPositions()
        {
            await Task.Delay(100);
            Dispatcher.Invoke(() =>
            {
                double max = 0;
                for (int i = 1; i <= buttonsLevel.Count; i++)
                {
                    var buttons = buttonsLevel[i];
                    for (int j = 0; j < buttons.Count; j++)
                    {
                        Canvas.SetTop(buttons[j], (i - 1) * 150);
                        if (j == 0)
                        {
                            Canvas.SetLeft(buttons[j], 0);
                            continue;
                        }
                        Canvas.SetLeft(buttons[j], buttons[j - 1].ActualWidth + 50 + Canvas.GetLeft(buttons[j - 1]));
                        if (max < Canvas.GetLeft(buttons[j - 1]))
                            max = Canvas.GetLeft(buttons[j - 1]);
                    }
                }
                diagram.Width = max;
            });
        }

        private async Task PaintLines()
        {
            await Task.Delay(100);
            Dispatcher.Invoke(() =>
            {
                double max = 0;
                for (int i = 1; i <= buttonsLevel.Count; i++)
                {
                    var buttons = buttonsLevel[i];
                    for (int j = 0; j < buttons.Count; j++)
                    {
                        PaintLine(buttons[j],i);
                    }
                }
            });
        }

        void PaintLine(Button buttonStart, int i)
        {
            var start = buttonStart.Tag as Department;
            double x1, x2, y1, y2;
            x1 = Canvas.GetLeft(buttonStart) + buttonStart.ActualWidth / 2;
            y1 = Canvas.GetTop(buttonStart) + buttonStart.ActualHeight + 5;

            foreach (var end in start.InverseIdMainDepNavigation)
            {
                foreach (var b in buttonsLevel[i + 1])
                {
                    if (b.Tag == end)
                    {
                        x2 = Canvas.GetLeft(b) + b.ActualWidth / 2;
                        y2 = Canvas.GetTop(b)+5;
                        Line line = new Line
                        {
                            X1 = x1,
                            Y1 = y1,
                            X2 = x2,
                            Y2 = y2,
                            Stroke = Brushes.Black
                        };
                        diagram.Children.Add(line);
                    }

                    PaintLine(b, i+1);
                }

            }
        }

        private void CheckInfoSelectedEmpl(object sender, MouseButtonEventArgs e)
        {
            CheckEmplInfo taskwind= new CheckEmplInfo(SelectedEmpl);
            taskwind.ShowDialog();
        }
    }
}