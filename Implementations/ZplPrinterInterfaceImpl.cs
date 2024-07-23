using XmlToZpl.Processors;
using XmlToZpl.Utils;
using XmlToZpl.Interfaces;
using System.Collections.Generic;
using System;
namespace XmlToZpl.Implementations
{
    //TODO SEE HOW TO USE THIS
    public class ZplPrinterInterfaceImpl : ZplPrinterInterface
    {
        public bool PrintLabel(string zplFilePath, List<Dictionary<string, string>> data)
        {
            try
            {
                ZplTemplateProcessor.ProcessAndPrintZplFile(zplFilePath, data);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public bool ConvertXmlToZpl(string xmlFilePath, string zplOutputFile)
        {
            try
            {
                string xmlContent = FileUtil.ReadFile(xmlFilePath);
                string zplCode = XmlToZplConverter.ConvertDynamicXmlToZpl(xmlContent);
                return FileUtil.WriteInFile(zplOutputFile, zplCode);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
    }
}