using XmlToZpl.Processors;
using XmlToZpl.Utils;
using System.Collections.Generic;
using System;
using XmlToZpl.Interfaces;

namespace XmlToZpl.Implementations
{
    public class ZplPrinterImpl : ZplPrinterBase
    {
        private int dpi;
        private string printerName;

        public ZplPrinterImpl(int dpi, string printerName)
        {
            this.dpi = dpi;
            this.printerName = printerName;
        }
        public override bool PrintLabel(string zplFilePath, List<Dictionary<string, string>> data)
        {
            try
            {
                return ZplTemplateProcessor.ProcessAndPrintZplFile(zplFilePath, data, this.printerName);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                LoggerUtil.LogError(ex, "ZplPrinterImpl", "PrintLabel");

                return false;
            }
        }

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
    }
}
