using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Linq;
using XmlToZpl.Utils;

namespace XmlToZpl.Processors
{
    public static class ZplTemplateProcessor
    {
        public static bool ProcessAndPrintZplFile(string templateZplFilePath, List<Dictionary<string, string>> variables, string printerName)
        {
            //TODO CRAETE A MODEL TO ADD QUANTITY
            string zplTemplate = FileUtil.ReadFile(templateZplFilePath);
            string zplToPrint = zplTemplate;
            string finalzpl = "";
            if (!String.IsNullOrEmpty(zplTemplate))
            {
                foreach (var item in variables)
                {
                    foreach (var variable in item)
                    {
                        Console.WriteLine(variable.Key + " " + variable.Value);
                        zplToPrint = zplToPrint?.Replace($"@{variable.Key}@", variable.Value);
                    }
                    finalzpl += zplToPrint;
                    zplToPrint = zplTemplate;
                }
                 if(RawPrinterHelper.SendStringToPrinter(printerName, finalzpl))
                {
                    return true;
                }
            }

            return false;
        }
        public static string MapTemplate(string zplTemplateCode, Dictionary<string, string> mapDictionarry)
        {
            foreach (var variable in mapDictionarry)
            {
                zplTemplateCode = zplTemplateCode?.Replace($"@{variable.Key}@", $"@{variable.Value}@");
            }
            return zplTemplateCode;
        }

        public static bool AddMappingVariablesToXml(string xmlFilePath, Dictionary<string, string> mapDictionary)
        {
            try
            {
                string xmlContent = FileUtil.ReadFile(xmlFilePath);
                XDocument xml = XDocument.Parse(xmlContent);

                foreach (var element in xml.Root?.Element("Items")?.Elements())
                {
                    XAttribute nameAttribute = element.Attribute("Name");
                    if (nameAttribute != null)
                    {
                        string nameValue = nameAttribute.Value;
                        if (mapDictionary.ContainsKey(nameValue))
                        {
                            string dbNameValue = mapDictionary[nameValue];
                            element.SetAttributeValue("DbColumnName", dbNameValue);
                        }
                    }
                }

                string directoryPath = "./modeles";
                if (!Directory.Exists(directoryPath))
                {
                    Directory.CreateDirectory(directoryPath);
                }

                string fileName = Path.GetFileName(xmlFilePath);
                string newFilePath = Path.Combine(directoryPath, fileName);

                xml.Save(newFilePath);

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error updating XML: " + ex.Message);
                return false;
            }
        }
    }

}
