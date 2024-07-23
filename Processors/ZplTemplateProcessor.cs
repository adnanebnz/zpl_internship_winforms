using System;
using System.Collections.Generic;
using XmlToZpl.Utils;

namespace XmlToZpl.Processors
{
    public static class ZplTemplateProcessor
    {
        public static void ProcessAndPrintZplFile(string templateZplFilePath, List<Dictionary<string, string>> variables)
        {
            //TODO CRAETE A MODEL TO ADD QUANTITY
            string template = FileUtil.ReadFile(templateZplFilePath);
            if (!String.IsNullOrEmpty(template))
            {
                foreach (var item in variables)
                {
                    foreach (var variable in item)
                    {
                        template = template?.Replace($"@{variable.Key}@", variable.Value);
                    }
                    FileUtil.WriteInFile("./dynamicZpl.zpl", template);
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

