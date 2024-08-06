using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using XmlToZpl.Models;

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
            catch (Exception e)
            {
                Console.WriteLine(e);
                columnNames.Clear();
            }
            return columnNames;
        }

        public List<Bien> FetchBienDataFromDb()
        {
            List<Bien> biens = new List<Bien>();
            try
            {
                using (SqlConnection connection = GetConnection())
                {
                    OpenConnection(connection);

                    SqlCommand command = connection.CreateCommand();
                    command.CommandType = CommandType.Text;
                    string stmt = "SELECT * FROM Bien";
                    command.CommandText = stmt;

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Bien bien = new Bien();

                            bien.IdBien = reader["IdBien"].ToString();
                            bien.IdCategorieBien = Convert.ToInt32(reader["IdCategorieBien"]);
                            bien.IdBienSeq = Convert.ToInt32(reader["IdBienSeq"]);
                            bien.DesigBien = reader["DesigBien"].ToString();
                            bien.DateAcquisitionBien = Convert.ToDateTime(reader["DateAcquisitionBien"]);
                            bien.personne = reader["personne"].ToString();
                            bien.Prix = Convert.ToDouble(reader["Prix"]);
                            bien.Photo = reader["Photo"].ToString();
                            bien.ancienCode = reader["ancienCode"].ToString();
                            bien.idFournisseur = Convert.ToInt32(reader["idFournisseur"]);
                            bien.Marque = reader["Marque"].ToString();
                            bien.numSerie = reader["numSerie"].ToString();
                            bien.Fournisseur = reader["Fournisseur"].ToString();
                            bien.etat = reader["etat"].ToString();
                            bien.DateMiseService = Convert.ToDateTime(reader["DateMiseService"]);
                            bien.natureBien = reader["natureBien"].ToString();
                            bien.idUtilisateur = Convert.ToInt32(reader["idUtilisateur"]);
                            bien.Model = reader["Model"].ToString();
                            bien.ancienCodeBarre = reader["ancienCodeBarre"].ToString();
                            bien.dernierEmplacement = reader["dernierEmplacement"].ToString();
                            bien.réetiqueter = Convert.ToBoolean(reader["réetiqueter"]);
                            bien.idBienMobil = reader["idBienMobil"].ToString();
                            bien.idEmploye = Convert.ToInt32(reader["idEmploye"]);
                            bien.idSociete = Convert.ToInt32(reader["idSociete"]);
                            bien.ficheImmobilisation = reader["ficheImmobilisation"].ToString();
                            bien.codeAmortissement = reader["codeAmortissement"].ToString();
                            bien.datecession = reader["datecession"].ToString();
                            bien.datederniereaffectation = reader["datederniereaffectation"].ToString();

                            biens.Add(bien);
                        }
                    }

                    CloseConnection(connection);
                }

                return biens;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error fetching Bien data: " + e.Message);
                biens.Clear();
                return biens;
            }
        }
        public List<Label> FetchLabelsFromDb()
        {
            List<Label> labels = new List<Label>();
            try
            {
                using (SqlConnection connection = GetConnection())
                {
                    OpenConnection(connection);

                    SqlCommand command = connection.CreateCommand();
                    command.CommandType = CommandType.Text;
                    string stmt = "SELECT * FROM Labels";
                    command.CommandText = stmt;

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Label label = new Label();
                            label.Id = Convert.ToInt32(reader["Id"]);
                            label.ModeleParDefaut = Convert.ToInt32(reader["ModeleParDefaut"]);
                            label.NomLabel = reader["NomLabel"].ToString();
                            label.CheminLabel = reader["CheminLabel"].ToString();
                            label.CheminZpl = reader["CheminZpl"].ToString();

                            labels.Add(label);
                        }
                    }

                    CloseConnection(connection);
                }

                return labels;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error fetching Label data: " + e.Message);
                labels.Clear();
                return labels;
            }
        }

        public bool SelectLabelIfExists(Label label)
        {
            bool labelExists = false;

            try
            {
                using (SqlConnection connection = GetConnection())
                {
                    OpenConnection(connection);

                    SqlCommand command = connection.CreateCommand();
                    command.CommandType = CommandType.Text;
                    command.CommandText = "SELECT * FROM Labels WHERE NomLabel = @NomLabel";
                    command.Parameters.AddWithValue("@NomLabel", (object)label.NomLabel ?? DBNull.Value);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            labelExists = true;

                            label.Id = Convert.ToInt32(reader["Id"]);
                            label.ModeleParDefaut = Convert.ToInt32(reader["ModeleParDefaut"]);
                            label.NomLabel = reader["NomLabel"].ToString();
                            label.CheminLabel = reader["CheminLabel"].ToString();
                            label.CheminZpl = reader["CheminZpl"].ToString();
                        }
                    }

                    CloseConnection(connection);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error fetching Label data: " + e.Message);
            }

            return labelExists;
        }

        public bool InsertLabelIntoDb(Label label)
        {
            try
            {
                if (!SelectLabelIfExists(label))
                {
                    using (SqlConnection connection = GetConnection())
                    {
                        OpenConnection(connection);

                        SqlCommand command = connection.CreateCommand();
                        command.CommandType = CommandType.Text;
                        command.CommandText = "INSERT INTO Labels (NomLabel, CheminLabel, CheminZpl) VALUES (@NomLabel, @CheminLabel, @CheminZpl)";

                        command.Parameters.AddWithValue("@NomLabel", (object)label.NomLabel ?? DBNull.Value);
                        command.Parameters.AddWithValue("@CheminLabel", (object)label.CheminLabel ?? DBNull.Value);
                        command.Parameters.AddWithValue("@CheminZpl", (object)label.CheminZpl ?? DBNull.Value);

                        int rowsAffected = command.ExecuteNonQuery();

                        // Close the connection after the operation
                        CloseConnection(connection);

                        return rowsAffected > 0;
                    }
                }
                else
                {
                    return false;
                }
            }
            catch (SqlException sqlEx)
            {
                Console.WriteLine("SQL Error inserting Label data: " + sqlEx.Message);
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error inserting Label data: " + ex.Message);
                return false;
            }
        }

        public bool DeleteLabelFromDb(Label label)
        {
            try
            {
                if (!string.IsNullOrEmpty(label.CheminZpl) && File.Exists(label.CheminZpl))
                {
                    File.Delete(label.CheminZpl);
                }

                if (!string.IsNullOrEmpty(label.CheminLabel) && File.Exists(label.CheminLabel))
                {
                    File.Delete(label.CheminLabel);
                }

                using (SqlConnection connection = GetConnection())
                {
                    OpenConnection(connection);

                    SqlCommand command = connection.CreateCommand();
                    command.CommandType = CommandType.Text;
                    command.CommandText = "DELETE FROM Labels WHERE Id = @Id";

                    command.Parameters.AddWithValue("@Id", (object)label.Id ?? DBNull.Value);

                    int rowsAffected = command.ExecuteNonQuery();
                    CloseConnection(connection);

                    return rowsAffected > 0;
                }
            }
            catch (SqlException sqlEx)
            {
                Console.WriteLine("SQL Error deleting Label data: " + sqlEx.Message);
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error deleting Label data: " + ex.Message);
                return false;
            }
        }
        public bool ModifyLabelStatus(int status, int labelId)
        {
            try
            {
                using (SqlConnection connection = GetConnection())
                {
                    OpenConnection(connection);

                    using (SqlCommand command = connection.CreateCommand())
                    {
                        command.CommandType = CommandType.Text;
                        command.CommandText = "UPDATE Labels SET ModeleParDefaut = @ModeleParDefaut WHERE Id = @Id";

                        command.Parameters.AddWithValue("@ModeleParDefaut", status);
                        command.Parameters.AddWithValue("@Id", labelId);

                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error modifying Label status: " + e.Message);
                return false;
            }
        }

    }
}
