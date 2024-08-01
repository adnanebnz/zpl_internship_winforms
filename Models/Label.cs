using System;

namespace XmlToZpl.Models
{
    public class Label
    {
        public string NomLabel { get; set; }
        public string CheminLabel { get; set; }
        public string CheminZpl { get; set; }
        public override string ToString()
        {
            return $"Label: {NomLabel}, Chemin: {CheminLabel}";
        }
    }
}
