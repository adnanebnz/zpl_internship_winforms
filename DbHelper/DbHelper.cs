using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace XmlToZpl.DbHelper
{
    public class DatabaseHelper
    {
        private string connectionString;

        public DatabaseHelper(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }

        public void OpenConnection(SqlConnection connection)
        {
            if (connection.State != ConnectionState.Open)
            {
                connection.Open();
            }
        }

        public void CloseConnection(SqlConnection connection)
        {
            if (connection.State != ConnectionState.Closed)
            {
                connection.Close();
            }
        }

        public List<string> GetTableColumnNames(string tableName)
        {
            List<string> columnNames = new List<string>();

            try
            { 

            using (SqlConnection connection = GetConnection())
            {
                OpenConnection(connection);

                SqlCommand command = connection.CreateCommand();
                command.CommandType = CommandType.Text;
                string f = "SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = '" + tableName + "'";
                command.CommandText = f;


                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string columnName = reader.GetString(0);
                        columnNames.Add(columnName);
                    }
                }

                CloseConnection(connection);
            }

            return columnNames;
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
                 columnNames.Clear();
            }
            return columnNames;
        }
    }
}
