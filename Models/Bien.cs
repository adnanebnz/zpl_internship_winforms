using System;

namespace XmlToZpl.Models
{
    public class Bien
    {
        public string IdBien { get; set; }  // Assuming varchar(254) maps to string
        public int IdCategorieBien { get; set; }
        public int IdBienSeq { get; set; }
        public string DesigBien { get; set; } // Assuming varchar(254) maps to string
        public DateTime DateAcquisitionBien { get; set; }
        public string personne { get; set; } // Assuming varchar(254) maps to string
        public double Prix { get; set; } // Assuming float maps to double
        public string Photo { get; set; } // Assuming nvarchar(254) maps to string
        public string ancienCode { get; set; } // Assuming varchar(254) maps to string
        public int idFournisseur { get; set; }
        public string Marque { get; set; } // Assuming varchar(254) maps to string
        public string numSerie { get; set; } // Assuming varchar(254) maps to string
        public string Fournisseur { get; set; } // Assuming varchar(254) maps to string
        public string etat { get; set; } // Assuming varchar(20) maps to string
        public DateTime DateMiseService { get; set; }
        public string natureBien { get; set; } // Assuming varchar(100) maps to string
        public int idUtilisateur { get; set; }
        public string Model { get; set; } // Assuming varchar(100) maps to string
        public string ancienCodeBarre { get; set; } // Assuming varchar(100) maps to string
        public string dernierEmplacement { get; set; } // Assuming varchar(50) maps to string
        public bool réetiqueter { get; set; } // Assuming bit maps to bool
        public string idBienMobil { get; set; } // Assuming varchar(50) maps to string
        public int idEmploye { get; set; }
        public int idSociete { get; set; }
        public string ficheImmobilisation { get; set; } // Assuming nvarchar(150) maps to string
        public string codeAmortissement { get; set; } // Assuming nvarchar(100) maps to string
        public string datecession { get; set; } // Assuming nvarchar(50) maps to string
        public string datederniereaffectation { get; set; } // Assuming nvarchar(50) maps to string

        public override string ToString()
        {
            return $"[IdBien: {IdBien}, IdCategorieBien: {IdCategorieBien}, IdBienSeq: {IdBienSeq}, DesigBien: {DesigBien}, " +
                   $"DateAcquisitionBien: {DateAcquisitionBien}, personne: {personne}, Prix: {Prix}, Photo: {Photo}, " +
                   $"ancienCode: {ancienCode}, idFournisseur: {idFournisseur}, Marque: {Marque}, numSerie: {numSerie}, " +
                   $"Fournisseur: {Fournisseur}, etat: {etat}, DateMiseService: {DateMiseService}, natureBien: {natureBien}, " +
                   $"idUtilisateur: {idUtilisateur}, Model: {Model}, ancienCodeBarre: {ancienCodeBarre}, dernierEmplacement: {dernierEmplacement}, " +
                   $"réetiqueter: {réetiqueter}, idBienMobil: {idBienMobil}, idEmploye: {idEmploye}, idSociete: {idSociete}, " +
                   $"ficheImmobilisation: {ficheImmobilisation}, codeAmortissement: {codeAmortissement}, datecession: {datecession}, " +
                   $"datederniereaffectation: {datederniereaffectation}]";
        }
    }
}