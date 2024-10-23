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
        public MainWindow()
        {
            fileHandling fileHandler =  new fileHandling();
            ObservableCollection<employeeModel> employeeList = new ObservableCollection<employeeModel>();
            employeeList.Add(new employeeModel(1, "Marek", "Browarek", 1000));
            fileHandler.WriteEmployeesToJSON(employeeList);
            employeeList = fileHandler.GetEmployeesFromJSON();
            InitializeComponent();
        }
    }
}
