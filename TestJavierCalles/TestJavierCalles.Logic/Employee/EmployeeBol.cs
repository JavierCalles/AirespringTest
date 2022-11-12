using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TestJavierCalles.DataBase.Employee;
using TestJavierCalles.DataBase.Interfaz;
using TestJavierCalles.Dto;
using TestJavierCalles.Logic.Interfaz;

namespace TestJavierCalles.Logic.Employee
{
    public class EmployeeBol:IEmployeeBol
    {
        /// <summary>
        /// Object for access to data layer
        /// </summary>
        private readonly IEmployeeDao employeeDao = new EmployeeDao();
        
        public bool AddEmployee(EmployeeDto employee)
        {
          return  employeeDao.SetEmployee(employee);
           
        }
        
        public List<EmployeeDto> SearchEmployee(SearchEmployeeDto search)
        {
           return employeeDao.SearchEmployee(search);
         
        }
        public bool UpdateEmployee(EmployeeDto employee)
        {
            return employeeDao.SetEmployee(employee);

        }

        public bool DeleteEmployee(int idEmployee)
        {
            return employeeDao.DeleteEmployee(idEmployee);

        }


    }
}