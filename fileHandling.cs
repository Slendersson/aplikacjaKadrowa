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
                MessageBox.Show("Nie można odnaleźć pliku z pracownikami!", "Kurka wodna...");
                return null;
            }
            using(StreamReader file = File.OpenText(filepath))
            {
                employees = (ObservableCollection<employeeModel>)serializer.Deserialize(file, typeof(employeeModel));
            }
            return employees;
        }

        public void WriteEmployeesToJSON(ObservableCollection<employeeModel> employeeList)
        {
            
            if (!File.Exists(filepath))
            {
                File.Create(filepath);
            }
            File.WriteAllText(filepath, "");
            StreamWriter writer = new StreamWriter(File.OpenWrite(filepath));
            serializer.Serialize(writer, employeeList);
            
        }
        
    }
}
