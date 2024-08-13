using System.Collections.Generic;

namespace XmlToZpl.Interfaces
{
    public abstract class ZplPrinterBase
    {
        public abstract bool PrintLabel(string zplFilePath, List<Dictionary<string, string>> data);
    }
}