using System.Collections.Generic;
namespace XmlToZpl.Interfaces
{
    public interface ZplPrinterInterface
    {
        bool PrintLabel(string zplFilepath, List<Dictionary<string, string>> data);

        bool ConvertXmlToZpl(string xmlFilePath, string zplOutputFile);
    }
}