using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;
using System.Windows;

namespace SQLLib
{
    public class SQL
    {
        public static DataTable ReturnDT(string Query, string ConStr, out string exception)
        {
            DataTable dataTable = new DataTable();

            try
            {
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(Query, ConStr);
                sqlDataAdapter.Fill(dataTable);
                exception = String.Empty;
            }
            catch (Exception ex)
            {
                exception = ex.Message;
            }
            return dataTable;
        }

        public static int NoReturn(string Query, string ConStr, out string exception)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(ConStr))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(Query, connection);
                    command.ExecuteNonQuery(); //Выполнение запроса без возращения данных
                    connection.Close();

                    exception = String.Empty;
                }
                return 0;
            }
            catch (Exception ex)
            {
                exception = ex.Message;
                return 1;
            }
        }
    }
}
