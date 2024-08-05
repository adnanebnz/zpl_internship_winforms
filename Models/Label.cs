using System;

namespace XmlToZpl.Models
{
    public class Label
    {
        // add verification par rapport NomLabel update status, dossier configModeleImpression qui conteint fichiers xml transferer et zpl avec le meme nom
        // supression des fichiers l'ors de la supression d'un enregistrement
        public int Id { get; set; }
        public string NomLabel { get; set; }
        public string CheminLabel { get; set; }
        public string CheminZpl { get; set; }
        public int ModeleParDefaut { get; set; }
        public override string ToString()
        {
            return $"Label: Id {Id}, {NomLabel}, Chemin: {CheminLabel}, ModeleParDefaut: {ModeleParDefaut}";
        }
    }
}
