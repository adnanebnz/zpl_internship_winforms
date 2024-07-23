using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
            catch(Exception e)
            {
                Console.WriteLine(e);
                 columnNames.Clear();
            }
            return columnNames;
        }

        public List<Bien> FetchBienDataFromDb()
        {
            List<Bien> biens = new List<Bien>();
            //INTERFACE AND IMPLEMENTATION OF 2 METHODS XMLTOZPL(cheminXml,zplOutputFilePath) AND PRINTLABEL(dictionarry or json as data, cheminZpl)
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
                throw; // Rethrow the exception to handle it appropriately at the higher level
            }
        }


    }
}
