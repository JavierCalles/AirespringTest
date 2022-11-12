using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TestJavierCalles.DataBase
{
    public static class DataAccess
    {
        /// <summary>
        /// Creates the connection.
        /// </summary>
        /// <returns></returns>
        private static SqlConnection CreateConnection()
        {
            return new SqlConnection(ConfigurationManager.ConnectionStrings["DBEmployee"].ConnectionString);
        }

        /// <summary>
        /// Executes the non query.
        /// </summary>
        /// <param name="commandText">The command text.</param>
        /// <param name="parameters">The parameters.</param>
        public static void ExecuteNonQuery(string commandText, params object[] parameters)
        {
            using (SqlConnection cnn = CreateConnection())
            {
                try
                {
                    using (SqlCommand cmd = new SqlCommand(commandText, cnn))
                    {
                        cnn.Open();
                        int index = 0;
                        foreach (object item in parameters)
                        {
                            string parameterName = "@p" + index;
                            if (item != null)
                            {
                                cmd.Parameters.AddWithValue(parameterName, item);
                            }
                            else
                            {
                                cmd.Parameters.AddWithValue(parameterName, DBNull.Value);
                            }
                            index++;
                        }

                        cmd.ExecuteNonQuery();

                        cnn.Close();
                    }
                }
                finally
                {
                    if (cnn.State == System.Data.ConnectionState.Open)
                    {
                        cnn.Close();
                    }
                }
            }
        }


        /// <summary>
        /// Executes the non query.
        /// </summary>
        /// <param name="commandText">The command text.</param>
        /// <param name="parameters">The parameters.</param>
        public static void ExecuteNonQuery(string commandText, SqlParameter[] parameters)
        {
            using (SqlConnection cnn = CreateConnection())
            {
                try
                {
                    using (SqlCommand cmd = new SqlCommand(commandText, cnn))
                    {
                        cnn.Open();
                        int index = 0;
                        foreach (SqlParameter item in parameters)
                        {
                            string parameterName = "@p" + index;
                            if (item != null)
                            {
                                cmd.Parameters.AddWithValue(parameterName, item.Value);
                            }
                            else
                            {
                                cmd.Parameters.AddWithValue(parameterName, DBNull.Value);
                            }
                            index++;
                        }

                        cmd.ExecuteNonQuery();

                        cnn.Close();
                    }
                }
                finally
                {
                    if (cnn.State == System.Data.ConnectionState.Open)
                    {
                        cnn.Close();
                    }
                }
            }
        }


        /// <summary>
        /// Executes the scalar.
        /// </summary>
        /// <param name="commandText">The command text.</param>
        /// <param name="parameters">The parameters.</param>
        /// <returns></returns>
        public static object ExecuteScalar(string commandText, params object[] parameters)
        {
            object result = null;
            using (SqlConnection cnn = CreateConnection())
            {
                try
                {
                    using (SqlCommand cmd = new SqlCommand(commandText, cnn))
                    {
                        cnn.Open();
                        int index = 0;
                        foreach (object item in parameters)
                        {
                            string parameterName = "@p" + index;
                            if (item != null)
                            {
                                cmd.Parameters.AddWithValue(parameterName, item);
                            }
                            else
                            {
                                cmd.Parameters.AddWithValue(parameterName, DBNull.Value);
                            }
                            index++;
                        }

                        result = cmd.ExecuteScalar();

                        cnn.Close();
                    }
                }
                finally
                {
                    if (cnn.State == System.Data.ConnectionState.Open)
                    {
                        cnn.Close();
                    }
                }
            }
            return result;
        }


        /// <summary>
        /// Executes the scalar.
        /// </summary>
        /// <param name="commandText">The command text.</param>
        /// <param name="parameters">The parameters.</param>
        /// <returns></returns>
        public static object ExecuteScalar(string commandText, SqlParameter[] parameters)
        {
            object result = null;
            using (SqlConnection cnn = CreateConnection())
            {
                try
                {
                    using (SqlCommand cmd = new SqlCommand(commandText, cnn))
                    {
                        cnn.Open();
                        int index = 0;
                        foreach (SqlParameter item in parameters)
                        {
                            string parameterName = "@p" + index;
                            if (item.Value != null)
                            {
                                cmd.Parameters.AddWithValue(parameterName, item.Value);
                            }
                            else
                            {
                                cmd.Parameters.AddWithValue(parameterName, DBNull.Value);
                            }
                            index++;
                        }

                        result = cmd.ExecuteScalar();

                        cnn.Close();
                    }
                }
                finally
                {
                    if (cnn.State == System.Data.ConnectionState.Open)
                    {
                        cnn.Close();
                    }
                }
            }
            return result;
        }





        /// <summary>
        /// Executes the data table.
        /// </summary>
        /// <param name="commandText">The command text.</param>
        /// <param name="parameters">The parameters.</param>
        /// <returns></returns>
        public static DataTable ExecuteDataTable(string commandText, params object[] parameters)
        {
            DataTable result = new DataTable();
            using (SqlConnection cnn = CreateConnection())
            {
                try
                {
                    using (SqlCommand cmd = new SqlCommand(commandText, cnn))
                    {
                        cnn.Open();
                        int index = 0;
                        foreach (object item in parameters)
                        {
                            string parameterName = "@p" + index;
                            if (item != null)
                            {
                                cmd.Parameters.AddWithValue(parameterName, item);
                            }
                            else
                            {
                                cmd.Parameters.AddWithValue(parameterName, DBNull.Value);
                            }
                            index++;
                        }

                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(result);
                        }
                        cnn.Close();
                    }
                }
                finally
                {
                    if (cnn.State == System.Data.ConnectionState.Open)
                    {
                        cnn.Close();
                    }
                }
            }
            return result;
        }

        /// <summary>
        /// Converts the data table.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dt">The dt.</param>
        /// <returns></returns>
        public static List<T> ConvertDataTable<T>(DataTable dt)
        {
            List<T> data = new List<T>();
            foreach (DataRow row in dt.Rows)
            {
                T item = GetItem<T>(row);
                data.Add(item);
            }
            return data;
        }

        /// <summary>
        /// Gets the item.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dr">The dr.</param>
        /// <returns></returns>
        public static T GetItem<T>(DataRow dr)
        {
            Type temp = typeof(T);
            T obj = Activator.CreateInstance<T>();

            foreach (DataColumn column in dr.Table.Columns)
            {
                foreach (PropertyInfo pro in temp.GetProperties())
                {
                    if (pro.Name == column.ColumnName && (dr[column.ColumnName] != DBNull.Value))
                    {
                        pro.SetValue(obj, dr[column.ColumnName], null);
                    }
                }
            }
            return obj;
        }

    }
}
