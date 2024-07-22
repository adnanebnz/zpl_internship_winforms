using System;
using System.Data;
using System.Data.SqlClient;
namespace DbHelper
{

public class DbHelper
{
    private string connectionString;

    public DbHelper(string connectionString)
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
}
    public List<string> GetTableColumnNames(string tableName)
    {
        List<string> columnNames = new List<string>();

        using (SqlConnection connection = GetConnection())
        {
            OpenConnection(connection);

            SqlCommand command = connection.CreateCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = $"SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = @TableName";

            command.Parameters.AddWithValue("@TableName", tableName);

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
}
