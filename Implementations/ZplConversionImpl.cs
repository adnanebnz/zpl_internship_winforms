using XmlToZpl.Utils;
using System;
using XmlToZpl.Interfaces;

namespace XmlToZpl.Implementations
{
    public class ZplCovnversionImpl : ZplConversionBase
    {
        private int dpi;

        public ZplCovnversionImpl(int dpi)
        {
            this.dpi = dpi;
        }

        // CONVERTING XML TO ZPL WITH VARIABLES (BETWEEN @@) IF THERE IS DYNAMIC VARIABLES INSIDE THE XML 
        public override bool ConvertXmlToZpl(string xmlFilePath, string zplOutputFile)
        {
            try
            {
                string xmlContent = FileUtil.ReadFile(xmlFilePath);
                string zplCode = XmlToZplConverter.ConvertDynamicXmlToZpl(xmlContent, this.dpi);
                return FileUtil.WriteInFile(zplOutputFile, zplCode);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                LoggerUtil.LogError(ex, "ZplPrinterImpl", "ConvertXmlToZpl");
                return false;
            }
        }

        // TO USE BEFORE MAPPING
        public override string GetZplCode(string xmlFilePath)
        {
            return XmlToZplConverter.ConvertDynamicXmlToZpl(xmlFilePath, this.dpi);
        }
    }
}
