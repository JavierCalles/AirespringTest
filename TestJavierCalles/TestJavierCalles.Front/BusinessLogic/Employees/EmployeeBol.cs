using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TestJavierCalles.Dto;
using TestJavierCalles.Front.BusinessLogic.Interfaz;
using TestJavierCalles.Front.Models;
using TestJavierCalles.Front.Util;
using TestJavierCalles.Service.RemoteServices.Employees;
using TestJavierCalles.Service.RemoteServices.Interfaz;

namespace TestJavierCalles.Front.BusinessLogic.Employees
{
    public class EmployeeBol: IEmployeeBol
    {
        /// <summary>
        /// Object for access to service layer
        /// </summary>
        private readonly IEmployeeService employeeService = new EmployeeService();

        public bool AddEmployee(EmployeeModel employee)
        {
            if (employee is null)
            {
                throw new ArgumentNullException(nameof(employee));
            }

            return  employeeService.AddEmployee(ConvertDto.convertDto(employee));
        }

        public ListEmployee SearchEmployee(SearchEmployeeDto search)
        {
           return  ConvertDto.convertDto(employeeService.SearchEmployee(search));  
        }

        public bool UpdateEmployee(EmployeeModel employees)
        {
            if (employees is null)
            {
                throw new ArgumentNullException(nameof(employees));
            }

            return employeeService.UpdateEmployee(ConvertDto.convertDto(employees));

        }

        public bool DeleteEmployee(int idEmployee)
        {
            return employeeService.DeleteEmployee(idEmployee);

        }
    }
}