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

