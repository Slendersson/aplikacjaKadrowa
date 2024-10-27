using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace kadrowa
{
    public partial class MainWindow : Window
    {
        private ObservableCollection<employeeModel> employeeList = new ObservableCollection<employeeModel>();
        private fileHandling fileHandler = new fileHandling();
        public MainWindow()
        {
            employeeList = fileHandler.GetEmployeesFromJSON();
            InitializeComponent();
            dataGridMain.DataContext = employeeList;
        }

        private void addEmployeeClick(object sender, RoutedEventArgs e)
        {
            addEmployee addEmployeeWindow = new addEmployee(this);
            //addEmployeeWindow.
            addEmployeeWindow.Show();
        }
        
        public void UpdateEmployeeListFile()
        {
            fileHandler.WriteEmployeesToJSON(employeeList);
        }
        public void AddToEmployeeList(employeeModel newEmployee)
        {
            employeeList.Add(newEmployee);
            UpdateEmployeeListFile();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(dataGridMain.SelectedItem == null)
            {
                MessageBox.Show("Wybierz pracownika, którego chcesz edytować!", "Błąd!");
                return;
            }
            editEmployee editEmployeeWindow = new editEmployee(this);
            editEmployeeWindow.Show();
            
        }
    }
}
