using System;
using System.Collections.Generic;
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

namespace kadrowa
{
    /// <summary>
    /// Logika interakcji dla klasy addEmployee.xaml
    /// </summary>
    public partial class addEmployee : Window
    {
        private MainWindow mainWindow;
        public addEmployee(MainWindow thisMainWindow)
        {
            mainWindow = thisMainWindow;
            InitializeComponent();
        }
        public bool ValidateFields()
        {
            string newEmployeeIdTb = newEmployeeId.Text;
            string newEmployeeNameTb = newEmployeeName.Text;
            string newEmployeeSurnameTb = newEmployeeSurname.Text;
            string newEmployeeSalaryTb = newEmployeeSalary.Text;

            if(newEmployeeIdTb == string.Empty || !int.TryParse(newEmployeeIdTb, out _))
            {
                return false;
            }
            if (newEmployeeNameTb == string.Empty)
            {
                return false;
            }
            if (newEmployeeSurnameTb == string.Empty)
            {
                return false;
            }
            if (newEmployeeSalaryTb == string.Empty || !float.TryParse(newEmployeeSalaryTb, out _))
            {
                return false;
            }

            return true;
        }

        private void addEmployeeButtonClick(object sender, RoutedEventArgs e)
        {
            if (!ValidateFields())
            {
                MessageBox.Show("Wprowadzono niepoprawne dane do pól tekstowych!", "Błąd!", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                return;
            }
            employeeModel newEmployee = new employeeModel(
                int.Parse(newEmployeeId.Text),
                newEmployeeName.Text,
                newEmployeeSurname.Text,
                float.Parse(newEmployeeSalary.Text)
                );
            mainWindow.AddToEmployeeList(newEmployee);
            this.Close();
        }
    }
}
