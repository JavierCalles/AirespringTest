using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;
using TestJavierCalles.Dto;
using TestJavierCalles.Front.Models;

namespace TestJavierCalles.Front.Util
{
    /// <summary>
    /// ConvertDto is a tool for convert  models and dtos faster
    /// </summary>
    public static class ConvertDto
    {
        /// <summary>
        /// Convert a employee model to employee dto 
        /// </summary>
        /// <param name="employeeModel">Employee model</param>
        /// <returns></returns>
        public static EmployeeDto convertDto(EmployeeModel employeeModel)
        {
            return new EmployeeDto
            {
                EmployeeId = employeeModel.EmployeeId,
                EmployeeLastName = employeeModel.EmployeeLastName.Trim().ToUpper(),
                EmployeeFirstName = employeeModel.EmployeeFirstName.Trim().ToUpper(),
                EmployeePhone = employeeModel.EmployeePhone,
                EmployeeZip = employeeModel.EmployeeZip.ToString(),
                HireDate =  employeeModel.HireDate
            };
        }

        /// <summary>
        /// Convert a list employee dto to list Employee object 
        /// </summary>
        /// <param name="employeeDtos"></param>
        /// <returns></returns>
        public static ListEmployee convertDto(List<EmployeeDto> employeeDtos)
        {
            ListEmployee listEmployee = new ListEmployee();
             listEmployee.Employees = employeeDtos.Select(s => new EmployeeModel
            {
                EmployeeId = s.EmployeeId,
                EmployeeFirstName= s.EmployeeFirstName.Trim().ToUpper(),
                EmployeeLastName  = s.EmployeeLastName.Trim().ToUpper(),
                EmployeePhone= s.EmployeePhone,
                EmployeeZip= Convert.ToInt32(s.EmployeeZip),
                HireDate= s.HireDate
            }).OrderBy(s => s.HireDate).ToList();

            return listEmployee;
        }

    }
}