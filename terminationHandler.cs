using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace kadrowa
{
    internal class terminationHandler
    {
        public void terminateEmployee(ref employeeModel employeeToTerminate)
        {
            if(employeeToTerminate.employeeDateOfTermination == null)
            {
                employeeToTerminate.internalTerminateEmployee();
                MessageBox.Show("Pomyślnie zwolniono pracownika.", "Operacja przebiegła pomyślnie", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            MessageBox.Show("Nie można zwolnić zwolnionego pracownika!", "Błąd!", MessageBoxButton.OK, MessageBoxImage.Information);
        }

    }
}
