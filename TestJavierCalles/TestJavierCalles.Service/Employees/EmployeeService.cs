using System;
using System.Collections.Generic;
using System.IO.Pipes;
using System.Linq;
using System.Web;
using TestJavierCalles.Dto;
using TestJavierCalles.Service.RemoteServices.Interfaz;

namespace TestJavierCalles.Service.RemoteServices.Employees
{
    public class EmployeeService : IEmployeeService
    {
        /// <summary>
        /// Object for services consume
        /// </summary>
        private readonly RestApiConsumer ApiConsumer = new RestApiConsumer("http://localhost:54891/");
        public bool AddEmployee(EmployeeDto employee)
        {
            try
            {
                var result = ApiConsumer.Consume<bool>("Employee", "AddEmployee", employee, RestSharp.Method.POST);
                return result;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<EmployeeDto> SearchEmployee(SearchEmployeeDto search)
        {
          List<EmployeeDto> listEmployee;
            
          listEmployee =  ApiConsumer.Consume<List<EmployeeDto>>("Employee", "SearchEmployee",search, RestSharp.Method.POST);
           
            return listEmployee;
        }

        public bool UpdateEmployee(EmployeeDto  employee)
        {
            try
            {
                var result = ApiConsumer.Consume<bool>("Employee", "UpdateEmployee", employee, RestSharp.Method.PUT);
                return result;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeleteEmployee(int idEmployee)
        {
            try
            {
                var result = ApiConsumer.Consume<bool>("Employee", "DeleteEmployee", idEmployee, RestSharp.Method.DELETE);
                return result;
            }
            catch (Exception)
            {
                return false;
            }
        }

    }
}