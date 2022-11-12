using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestJavierCalles.Front.BusinessLogic.Employees;
using TestJavierCalles.Front.BusinessLogic.Interfaz;
using TestJavierCalles.Front.Models;
using System.Web.Optimization;
using TestJavierCalles.Dto;

namespace TestJavierCalles.Front.Controllers
{
    public class EmployeeController : Controller
    {
        /// <summary>
        /// Object for access to logic layer
        /// </summary>
        private readonly IEmployeeBol employeeBol = new EmployeeBol();

        public ActionResult Index(string lastName =  "",string phone= "")
        {
            ListEmployee listEmployee = employeeBol.SearchEmployee(new SearchEmployeeDto() { EmployeeLastName = lastName,EmployeePhone = phone});
            return View(listEmployee); 
        }
        /// <summary>
        /// Add new employee
        /// </summary>
        /// <param name="lastName">Employee last name</param>
        /// <param name="firstName">Employee first name</param>
        /// <param name="phone">Employee phone</param>
        /// <param name="zip">Employee zip</param>
        [HttpGet]
        public void AddEmployee(string lastName, string firstName, string phone, int zip)
        {
            try
            {
                EmployeeModel employee = new EmployeeModel();
                employee.EmployeeLastName = lastName;
                employee.EmployeeFirstName = firstName;
                employee.EmployeePhone = phone;
                employee.EmployeeZip = zip;

                if (employeeBol.AddEmployee(employee))
                {
                    TempData["Message"] = "Exito";
                }
                else
                {
                    TempData["Message"] = "Error";
                }
            }catch (Exception)
            {
                TempData["Message"] = "Error";
            }
        }

        /// <summary>
        /// Update an employee
        /// </summary>
        /// <param name="lastName">Employee last name</param>
        /// <param name="firstName">Employee first name</param>
        /// <param name="phone">Employee phone</param>
        /// <param name="employeeId">Employee id</param>
        [HttpPost]
        public void UpdateEmployee(string lastName, string firstName, string phone, int zip, string employeeId)
        {
            try
            {
                EmployeeModel employee = new EmployeeModel();
                employee.EmployeeLastName = lastName;
                employee.EmployeeFirstName = firstName;
                employee.EmployeePhone = phone;
                employee.EmployeeZip = zip;
                employee.EmployeeId = Convert.ToInt32(employeeId);

                if (employeeBol.UpdateEmployee(employee))
                {
                    TempData["Message"] = "Exito";
                }
                else
                {
                    TempData["Message"] = "Error";
                }
            }catch(Exception)
            {
                TempData["Message"] = "Error";
            }
        }

        /// <summary>
        /// Delete an employee
        /// </summary>
        /// <param name="IdEmployee">Employee Id</param>
        [HttpPost]
        public void DeleteEmployee(int IdEmployee)
        {
            try
            {
                if (employeeBol.DeleteEmployee(IdEmployee))
                {
                    TempData["Message"] = "Exito";
                }
                else
                {
                    TempData["Message"] = "Error";
                }
            }catch(Exception)
            {
                TempData["Message"] = "Error";
            }
        }

    }
}
    