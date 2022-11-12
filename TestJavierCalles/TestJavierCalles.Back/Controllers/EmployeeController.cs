using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TestJavierCalles.Dto;
using TestJavierCalles.Logic.Employee;
using TestJavierCalles.Logic.Interfaz;

namespace TestJavierCalles.Back.Controllers
{
    public class EmployeeController : ApiController
    {
        /// <summary>
        /// Object for access to logic layer
        /// </summary>
        IEmployeeBol employeeBol = new EmployeeBol();

        /// <summary>
        /// Add a new employe
        /// </summary>
        /// <param name="employee">Object employee</param>
        /// <returns>Response the action status</returns>
        [HttpPost]
        [Route("Employee/AddEmployee")]
        public bool AddEmployee([FromBody] EmployeeDto employee)
        {
            try
            {
                return employeeBol.AddEmployee(employee);
            }
            catch (Exception)
            {
                return false;
            }

        }

        /// <summary>
        /// Search employee, you can to search for last name and phone
        /// </summary>
        /// <param name="search">search Object containt lastname and phone</param>
        /// <returns>List employees</returns>
        [HttpPost]
        [Route("Employee/SearchEmployee")]
        public List<EmployeeDto> SearchEmployee([FromBody]SearchEmployeeDto search)
        {
            try
            {
                return employeeBol.SearchEmployee(search);
            }
            catch (Exception)
            {
                List<EmployeeDto> employeeDtos = new List<EmployeeDto>();
                return employeeDtos;
            }

        }

        /// <summary>
        /// Update employee by employeeid 
        /// </summary>
        /// <param name="employee">Object employee</param>
        /// <returns>Response the action status</returns>
        [HttpPut]
        [Route("Employee/UpdateEmployee")]
        public bool UpdateEmployee([FromBody] EmployeeDto employee)
        {
            try
            {
                return employeeBol.UpdateEmployee(employee);
            }
            catch (Exception)
            {
                return false;
            }

        }

        /// <summary>
        /// Delete an employee by employe id
        /// </summary>
        /// <param name="employeeId"></param>
        /// <returns>Response the action status</returns>
        [HttpDelete]
        [Route("Employee/DeleteEmployee")]
        public bool DeleteEmployee([FromBody] int employeeId)
        {
            try
            {
                return employeeBol.DeleteEmployee(employeeId);
            }
            catch (Exception)
            {
                return false;
            }

        }
    }
}
