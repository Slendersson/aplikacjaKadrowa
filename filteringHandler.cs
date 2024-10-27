using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace kadrowa
{
    internal class filteringHandler
    {
        public void evaluateAndUpdate(MainWindow mainWindow)
        {
            if(mainWindow.dataGridMain == null)
            {
                Console.WriteLine("datagrid not init yet, skipping");
                return;
            }
            int filteringMode = 0;
            List<ComboBoxItem> cbItems = new List<ComboBoxItem>() {mainWindow.cbAll, mainWindow.cbWorking, mainWindow.cbPrevious};
            foreach (ComboBoxItem item in cbItems)
            {
                if(item.IsSelected)
                {
                    filteringMode = cbItems.IndexOf(item);
                    break;
                }
            }

            switch (filteringMode)
            {
                case 0:
                    mainWindow.dataGridMain.DataContext = mainWindow.GetEmployeeList();
                    break;
                case 1:
                    var workingEmployeesQuery = from employee in mainWindow.GetEmployeeList() where employee.employeeDateOfTermination == null select employee;
                    mainWindow.dataGridMain.DataContext = workingEmployeesQuery;
                    break;
                case 2:
                    var terminatedEmployeesQuery = from employee in mainWindow.GetEmployeeList() where employee.employeeDateOfTermination != null select employee;
                    mainWindow.dataGridMain.DataContext = terminatedEmployeesQuery;
                    break;
            }
        }
    }
}
