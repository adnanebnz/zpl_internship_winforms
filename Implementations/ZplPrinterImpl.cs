using XmlToZpl.Processors;
using XmlToZpl.Utils;
using System.Collections.Generic;
using System;
using XmlToZpl.Interfaces;
using XmlToZpl.DbHelper;

namespace XmlToZpl.Implementations
{
    public class ZplPrinterImpl : ZplPrinterBase
    {
        private int dpi;
        private string printerName;
        private readonly DatabaseHelper dbHelper;
        private string connectionString = "server=localhost\\SQLEXPRESS;database=Inventaire BDD;Trusted_Connection=True;";

        public ZplPrinterImpl()
        {
            dbHelper = new DatabaseHelper(this.connectionString);
        }
        public ZplPrinterImpl(int dpi)
        {
            dbHelper = new DatabaseHelper(this.connectionString);
        }

        public ZplPrinterImpl(int dpi, string printerName)
        {
            this.printerName = printerName;
            dbHelper = new DatabaseHelper(this.connectionString);
        }

        // USING A ZPL FILE TO PRINT THE LABEL WITH DATA
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
    }
}
