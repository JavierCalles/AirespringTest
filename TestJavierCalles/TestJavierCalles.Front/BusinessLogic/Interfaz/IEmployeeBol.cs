using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestJavierCalles.Dto;
using TestJavierCalles.Front.Models;

namespace TestJavierCalles.Front.BusinessLogic.Interfaz
{
    public interface IEmployeeBol
    {
        bool AddEmployee(EmployeeModel clientes);
        ListEmployee SearchEmployee(SearchEmployeeDto search);
        bool UpdateEmployee(EmployeeModel clientes);
        bool DeleteEmployee(int EmployeeModel);
    }
}
