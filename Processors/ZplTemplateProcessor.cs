using System;
using System.Collections.Generic;
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
            if (!String.IsNullOrEmpty(zplTemplate))
            {
                foreach (var item in variables)
                {
                    foreach (var variable in item)
                    {
                        Console.WriteLine(variable.Key + " "+ variable.Value);
                        zplToPrint = zplToPrint?.Replace($"@{variable.Key}@", variable.Value);

                    }
                    RawPrinterHelper.SendStringToPrinter(printerName, zplToPrint);
                    // resetting and prepparing for the next print
                    zplToPrint = zplTemplate;
                    //todo temporarryfile
                    //todo add method to not overwrite file
                }
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
    }

}
