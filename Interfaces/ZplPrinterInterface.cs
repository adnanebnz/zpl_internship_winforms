using System.Collections.Generic;
namespace XmlToZpl.Interfaces
{
    public interface ZplPrinterInterface
    {
        bool PrintLabel(string zplFilepath, List<Dictionary<string, string>> data,string printerName);

        bool ConvertXmlToZpl(string xmlFilePath, string zplOutputFile);
    }
}