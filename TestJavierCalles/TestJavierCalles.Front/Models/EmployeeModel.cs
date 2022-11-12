using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestJavierCalles.Front.Models
{
    public class EmployeeModel
    {
        public int EmployeeId { get; set; }
        public string EmployeeLastName { get; set; }
        public string EmployeeFirstName { get; set; }
        public string EmployeePhone { get; set; }
        public int EmployeeZip { get; set; }
        public DateTime HireDate { get; set; }
    }

    public class ListEmployee
    {
        public List<EmployeeModel> Employees { get; set; }
    }

}