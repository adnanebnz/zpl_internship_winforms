
using System.Collections.Generic;
using XmlToZpl.Interfaces;
using XmlToZpl.Processors;

namespace XmlToZpl.Implementations
{
    public class ZplMappingImpl : ZplMappingBase
    {
        public override string MapZplTemplate(string zplTemplateCode, Dictionary<string, string> mappingDictionary)
        {
           string zplContent =  ZplTemplateProcessor.MapTemplate(zplTemplateCode, mappingDictionary);
            return zplContent;
        }

        public override bool SetDbColsToXml(string xmlFilePath, Dictionary<string, string> mappingDictionary)
        {
            // Add mapping variables to XML
            bool res = ZplTemplateProcessor.AddMappingVariablesToXml(xmlFilePath, mappingDictionary);

            return res;
        }
    }
}
