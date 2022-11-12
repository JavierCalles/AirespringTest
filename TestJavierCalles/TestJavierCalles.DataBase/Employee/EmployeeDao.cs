
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using TestJavierCalles.DataBase.Interfaz;
using TestJavierCalles.Dto;

namespace TestJavierCalles.DataBase.Employee
{
    public class EmployeeDao:IEmployeeDao
    {
        public bool SetEmployee(EmployeeDto employee)
        {

            try
            {
                string query = @"EXEC SetEmployee @p0,@p1,@p2,@p3,@p4";
                DataAccess.ExecuteNonQuery(query, employee.EmployeeLastName,employee.EmployeeFirstName,employee.EmployeePhone,employee.EmployeeZip,employee.EmployeeId);

                return true;

            }
            catch (Exception ex)
            {
                return false;
            }

           
        }

        public List<EmployeeDto> SearchEmployee(SearchEmployeeDto search)
        {

            try
            {
                string query = @"EXEC GetEmployees @p0,@p1";
                DataTable data = DataAccess.ExecuteDataTable(query,search.EmployeeLastName,search.EmployeePhone);

                return  DataAccess.ConvertDataTable<EmployeeDto>(data);

            }
            catch (Exception)
            {
                return new List<EmployeeDto>();
            }
        }


        public bool DeleteEmployee(int EmployeeId)
        {
            try
            {
                string query = @"EXEC DeleteEmployee @p0";
                DataAccess.ExecuteNonQuery(query, EmployeeId);

                return true;

            }
            catch (Exception)
            {
                return false;
            }

        }

    }
}