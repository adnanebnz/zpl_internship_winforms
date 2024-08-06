using System.Collections.Generic;

namespace XmlToZpl.Models
{
    public class PrintingModel
    {
        public string Quantity { get; set; }

        public Dictionary<string, string> variables { get; set; }
    }
}
