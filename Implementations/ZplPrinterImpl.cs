using XmlToZpl.Processors;
using XmlToZpl.Utils;
using System.Collections.Generic;
using System;
using XmlToZpl.Interfaces;
using System.IO;
using XmlToZpl.DbHelper;
using XmlToZpl.Models;

namespace XmlToZpl.Implementations
{
    public class ZplPrinterImpl : ZplPrinterBase
    {
        private int dpi;
        private string printerName;
        private readonly DatabaseHelper dbHelper;
        private string connectionString = "server=localhost\\SQLEXPRESS;database=Inventaire BDD;Trusted_Connection=True;";

        public ZplPrinterImpl(int dpi, string printerName)
        {
            this.dpi = dpi;
            this.printerName = printerName;
            dbHelper = new DatabaseHelper(this.connectionString);
        }

        // USING A ZPL FILE TO PRINT THE LABEL WITH DATA
        public override bool PrintLabel(string zplFilePath, List<Dictionary<string, string>> data)
        {
            try
            {
                return ZplTemplateProcessor.ProcessAndPrintZplFile(zplFilePath, data, this.printerName);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                LoggerUtil.LogError(ex, "ZplPrinterImpl", "PrintLabel");

                return false;
            }
        }

        // CONVERTING XML TO ZPL WITH VARIABLES (BETWEEN @@) IF THERE IS DYNAMIC VARIABLES INSIDE THE XML 
        public override bool ConvertXmlToZpl(string xmlFilePath, string zplOutputFile)
        {
            try
            {
                string xmlContent = FileUtil.ReadFile(xmlFilePath);
                string zplCode = XmlToZplConverter.ConvertDynamicXmlToZpl(xmlContent, this.dpi);
                return FileUtil.WriteInFile(zplOutputFile, zplCode);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                LoggerUtil.LogError(ex, "ZplPrinterImpl", "ConvertXmlToZpl");
                return false;
            }
        }
        // MAPPING XML TEMPLATE - WRITING MAPPING VARIABLES TO THE XML - SAVING THE CONFIG (XML and ZPL)
        // CREATING A CONFIG ROW IN DB
        public override string MapXmlTemplateAndSaveConfig(string xmlFilePath, Dictionary<string, string> mappingDictionary, string configName)
        {
            string zplResult = XmlToZplConverter.ConvertDynamicXmlToZpl(xmlFilePath, this.dpi);
            string result = ZplTemplateProcessor.MapTemplate(zplResult, mappingDictionary);

            // Add mapping variables to XML
            bool res = ZplTemplateProcessor.AddMappingVariablesToXml(xmlFilePath, mappingDictionary);

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
            FileUtil.WriteInFile(newFilePath, result);

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
            if (!res)
            {
                return "Error saving the file";
            }
            if (!registerResult)
            {
                return "Erreur, le nom de la config existe deja";
            }
            else
            {
                if (res)
                {
                    return "Xml Config saved!";
                }
            }
            return "success";
        }

        // DELETING A LABEL (from db and also the files stored inside modeles folder)
        public override bool DeleteLabelConfig(Models.Label label)
        {
            bool success = dbHelper.DeleteLabelFromDb(label);
            if (!success)
            {
                return false;
            }
            return true;
        }
    }
}
