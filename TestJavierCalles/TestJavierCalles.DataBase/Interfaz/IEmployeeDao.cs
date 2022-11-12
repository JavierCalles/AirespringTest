using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestJavierCalles.Dto;

namespace TestJavierCalles.DataBase.Interfaz
{
    public interface IEmployeeDao
    {
        bool SetEmployee(EmployeeDto employee);
        List<EmployeeDto> SearchEmployee(SearchEmployeeDto search);
        bool DeleteEmployee(int idEmployeeId);
    }
}
