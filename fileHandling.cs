using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;
using System.Net.Security;
using System.Windows;
using System.Runtime.Serialization;
using System.Runtime.CompilerServices;

namespace kadrowa
{
    internal class fileHandling
    {
        private JsonSerializer serializer = new JsonSerializer();
        private const string filepath = "../../employees.json";

        public ObservableCollection<employeeModel> GetEmployeesFromJSON()
        {
            ObservableCollection<employeeModel> employees = new ObservableCollection<employeeModel>();

            if(!File.Exists(filepath)) {
                MessageBox.Show("Nie można odnaleźć pliku z pracownikami!\nKontynuuj swoją pracę, a my go stworzymy! \n(Ewentualnie wrzuć istniejący już plik do folderu)", "Ups...", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                return null;
            }
            using(StreamReader file = File.OpenText(filepath))
            {
                employees = (ObservableCollection<employeeModel>)serializer.Deserialize(file, typeof(ObservableCollection<employeeModel>));
            }
            return employees;
        }

        public void WriteEmployeesToJSON(ObservableCollection<employeeModel> employeeList)
        {
            
            if (!File.Exists(filepath))
            {
                File.Create(filepath).Close(); //OD razu zamykamy, żeby niżej nie było płaczu o to, że inny proces ma otwarty uchwyt do tego pliku.
                
            }
            File.WriteAllText(filepath, "");
            StreamWriter writer = new StreamWriter(File.OpenWrite(filepath));
            serializer.Serialize(writer, employeeList);
            writer.Close();
        }
        
    }
}
