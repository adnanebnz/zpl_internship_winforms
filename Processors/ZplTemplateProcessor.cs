using System;
using System.Collections.Generic;
using System.Xml.Linq;
using XmlToZpl.Utils;

namespace XmlToZpl.Processors
{
    public static class ZplTemplateProcessor
    {
        public static void ProcessAndPrintZplFile(string templateZplFilePath, List<Dictionary<string, string>> variables, string printerName)
        {
            //TODO CRAETE A MODEL TO ADD QUANTITY
            string zplTemplate = FileUtil.ReadFile(templateZplFilePath);
            string zplToPrint = zplTemplate;
            string finalzpl = "";
            if (!String.IsNullOrEmpty(zplTemplate))
            {
                // ECRAN AJOUTER LISTE DES MODELES XML ET AFFICHER ET ADD ATTRIBUTE TO XML DANS LE MAPPING POUR LES VARIABLES BDD ET ENREGISTRER NE PAS ECRASER
                //AJOUTER ATTRIBUT TABLENAME XML QUI SPECIFIE LE NOM DE LA TABLE 
                //WE CAN KNOW THE CONFIG WHEN WE CHECK THE NAMES WITH DBNAME ATTRIBUTES FOR XML AND WE NEEDA  SCREEN FOR IT
                foreach (var item in variables)
                {
                    foreach (var variable in item)
                    {
                        Console.WriteLine(variable.Key + " " + variable.Value);
                        zplToPrint = zplToPrint?.Replace($"@{variable.Key}@", variable.Value);
                    }
                    finalzpl += zplToPrint;
                    // resetting and prepparing for the next print
                    zplToPrint = zplTemplate;
                }
                RawPrinterHelper.SendStringToPrinter(printerName, finalzpl);
            }
            else
            {

            }


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

                // Traverse through all elements
                //add an attrivute called TableName with an attribute Name that has the table Name
                foreach (var element in xml.Root?.Element("Items")?.Elements())
                {
                    // Check if the element has a Name attribute
                    XAttribute nameAttribute = element.Attribute("Name");
                    if (nameAttribute != null)
                    {
                        // Check if the Name attribute value exists in the dictionary
                        string nameValue = nameAttribute.Value;
                        if (mapDictionary.ContainsKey(nameValue))
                        {
                            string dbNameValue = mapDictionary[nameValue];
                            element.SetAttributeValue("DbColumnName", dbNameValue);
                        }
                    }
                }

                // Save the modified XML content back to the file
                xml.Save(xmlFilePath);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                return false;
            }

        }
    }

}
