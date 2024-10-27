using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kadrowa
{
    public class employeeModel
    {
        public Int32 employeeId { get; set; }
        public string employeeName { get; set; }
        public string employeeSurname { get; set; }
        public float employeeSalary { get; set; }
        public DateTime employeeDateOfEmployment { get; set; }
        public DateTime? employeeDateOfTermination { get; set; }

        public employeeModel(Int32 id, string name, string surname, float salary, DateTime? dateOfEmployment = null) {
            employeeId = id;
            employeeName = name;
            employeeSurname = surname;
            employeeSalary = salary;
            employeeDateOfEmployment = dateOfEmployment ?? DateTime.Now;
        }
    }
}
