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

    public partial class editEmployee : Window
    {
        private MainWindow mainWindow;
        private employeeModel editedEmployee;
        public editEmployee(MainWindow thisMainWindow)
        {
            mainWindow = thisMainWindow;
            editedEmployee = thisMainWindow.dataGridMain.SelectedItem as employeeModel;
            InitializeComponent();
            //Nie chce mi się tu męczyć z bindingiem (wymagałoby zmian w xaml'u) dlatego robię to po linii najmniejszego oporu :)
            newEmployeeId.Text = editedEmployee.employeeId.ToString();
            newEmployeeName.Text = editedEmployee.employeeName.ToString();
            newEmployeeSurname.Text = editedEmployee.employeeSurname.ToString();
            newEmployeeSalary.Text = editedEmployee.employeeSalary.ToString();
            newEmployeeDateOfEmployment.SelectedDate = editedEmployee.employeeDateOfEmployment;
        }

        private void editEmployeeButtonClick(object sender, RoutedEventArgs e)
        {
            if (!ValidateFields())
            {
                MessageBox.Show("Wprowadzono niepoprawne dane do pól tekstowych!", "Błąd!");
                return;
            }
            employeeModel newEmployee = new employeeModel(
                int.Parse(newEmployeeId.Text),
                newEmployeeName.Text,
                newEmployeeSurname.Text,
                float.Parse(newEmployeeSalary.Text),
                newEmployeeDateOfEmployment.SelectedDate
                );
            return;
        }
        public bool ValidateFields()
        {
            string newEmployeeIdTb = newEmployeeId.Text;
            string newEmployeeNameTb = newEmployeeName.Text;
            string newEmployeeSurnameTb = newEmployeeSurname.Text;
            string newEmployeeSalaryTb = newEmployeeSalary.Text;
            DateTime? newEmployeeDateOfEmploymentTb = newEmployeeDateOfEmployment.SelectedDate;

            if (newEmployeeIdTb == string.Empty || !int.TryParse(newEmployeeIdTb, out _))
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
            if (newEmployeeDateOfEmploymentTb > DateTime.Now || newEmployeeDateOfEmploymentTb == null)
            {
                return false; //Zakładamy, że nie jesteśmy w stanie zaginać czasoprzestrzeni.
            }
            return true;

        }
        }
    }
