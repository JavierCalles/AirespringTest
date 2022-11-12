using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestJavierCalles.Dto;

namespace TestJavierCalles.Service.RemoteServices.Interfaz
{
    public interface IEmployeeService
    {
        bool AddEmployee(EmployeeDto employee);
        List<EmployeeDto> SearchEmployee(SearchEmployeeDto search);
        bool UpdateEmployee(EmployeeDto employee);
        bool DeleteEmployee(int idEmployee);


    }
}
