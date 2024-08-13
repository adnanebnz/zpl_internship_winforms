using System.Collections.Generic;

namespace XmlToZpl.Interfaces
{
    public abstract class ZplMappingBase
    {
        public abstract bool SetDbColsToXml(string xmlFilePath, Dictionary<string, string> mappingDictionary);
        public abstract string MapZplTemplate(string zplFilePath, Dictionary<string, string> mappingDictionary);

    }
}
