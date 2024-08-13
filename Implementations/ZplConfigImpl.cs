using System;
using System.IO;
using XmlToZpl.DbHelper;
using XmlToZpl.Interfaces;
using XmlToZpl.Models;
using XmlToZpl.Utils;

namespace XmlToZpl.Implementations
{
    public class ZplConfigImpl : ZplConfigBase
    {
        private readonly DatabaseHelper dbHelper;

        public ZplConfigImpl()
        {
            this.dbHelper = new DatabaseHelper("server=localhost\\SQLEXPRESS;database=Inventaire BDD;Trusted_Connection=True;");
        }
        public override bool DeleteLabelConfig(Label label)
        {
            bool success = dbHelper.DeleteLabelFromDb(label);
            if (!success)
            {
                return false;
            }
            return true;
        }

        public override string SaveConfig(string xmlFilePath, string zplResult, string configName)
        {
            // Define the directory and ensure it exists
            string directoryPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "modeles");
            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }

            // Construct the new file path for the .zpl file
            string fileName = Path.GetFileNameWithoutExtension(xmlFilePath) + ".zpl";
            string newFilePath = Path.Combine(directoryPath, fileName);

            // Write the result to the new .zpl file
            FileUtil.WriteInFile(newFilePath, zplResult);

            // Create a new Label instance
            Models.Label label = new Models.Label
            {
                CheminLabel = Path.Combine(directoryPath, Path.GetFileName(xmlFilePath)),
                CheminZpl = newFilePath,
                NomLabel = configName
            };


            bool registerResult = dbHelper.InsertLabelIntoDb(label);
            if (String.IsNullOrEmpty(configName))
            {
                return "Please insert your config name";
            }

            if (!registerResult)
            {
                return "Erreur, le nom de la config existe deja";
            }
            return "success";
        }
    }
}
