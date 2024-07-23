using System;
using System.Collections.Generic;
using XmlToZpl.Utils;

namespace XmlToZpl.Processors
{
    public static class ZplTemplateProcessor
    {
        public static void ProcessTemplate(string templateZplFile, Dictionary<string, string> variables)
        {
                string template = FileUtil.ReadFile(templateZplFile);

                foreach (var variable in variables)
                {
                    template = template?.Replace($"@{variable.Key}@", variable.Value);
                }
                FileUtil.WriteInFile("./dynamicZpl.zpl", template);
            }
        public static void ProcessTemplate2(string templateZplFile, List<Dictionary<string, string>> variables)
        {
            //TODO CRAETE A MODEL TO ADD QUANTITY
            string template = FileUtil.ReadFile(templateZplFile);
            if (!String.IsNullOrEmpty(template))
            {
                foreach (var item in variables)
                {
                    foreach (var variable in item)
                    {
                        template = template?.Replace($"@{variable.Key}@", variable.Value);
                    }
                    FileUtil.WriteInFile("./dynamicZpl.zpl", template);
                    //temporarryfile
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

