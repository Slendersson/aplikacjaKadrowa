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
        private terminationHandler terminationHandler = new terminationHandler();
        private filteringHandler filteringHandler = new filteringHandler();
        public MainWindow()
        {
            if(fileHandler.GetEmployeesFromJSON() != null)
            {
                employeeList = fileHandler.GetEmployeesFromJSON();
            }
            
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

        public void EditEmployeeList(employeeModel employeeToRemove, employeeModel newEmployee)
        {
            int indexOfRemovedEmployee = employeeList.IndexOf(employeeToRemove);
            employeeList.Remove(employeeToRemove);
            employeeList.Insert(indexOfRemovedEmployee, newEmployee);
            UpdateEmployeeListFile();
        }

        public ObservableCollection<employeeModel> GetEmployeeList()
        {
            return employeeList;
        }
        private void editEmployee_Click(object sender, RoutedEventArgs e)
        {
            if(dataGridMain.SelectedItem == null)
            {
                MessageBox.Show("Wybierz pracownika, którego chcesz edytować!", "Błąd!", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                return;
            }
            if((dataGridMain.SelectedItem as employeeModel).employeeDateOfTermination != null)
            {
                MessageBox.Show("Nie możesz edytować zwolnionego pracownika!", "Błąd!", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                return;
            }

            editEmployee editEmployeeWindow = new editEmployee(this);
            editEmployeeWindow.Show();
        }
        
        

        private void terminateEmployee_Click(object sender, RoutedEventArgs e)
        {
            if (dataGridMain.SelectedItem == null)
            {
                MessageBox.Show("Wybierz pracownika, którego chcesz zwolnić!", "Błąd!", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                return;
            }
            employeeModel selectedEmployee = dataGridMain.SelectedItem as employeeModel;
            terminationHandler.terminateEmployee(ref selectedEmployee);
            UpdateEmployeeListFile();
        }

        private void filteringCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            filteringHandler.evaluateAndUpdate(this);
        }
    }
}
