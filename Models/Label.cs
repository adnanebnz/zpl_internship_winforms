using System;

namespace XmlToZpl.Models
{
    public class Label
    {
        public int Id { get; set; }
        public string NomLabel { get; set; }
        public string CheminLabel { get; set; }
        public string CheminZpl { get; set; }
        public int ModeleParDefaut { get; set; }
        public override string ToString()
        {
            return $"Label: Id {Id}, {NomLabel}, CheminLabel: {CheminLabel}, CheminZpl: {CheminZpl}, ModeleParDefaut: {ModeleParDefaut}";
        }
    }
}
