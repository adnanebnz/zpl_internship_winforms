using System;

namespace XmlToZpl.Models
{
    public class Bien
    {
        public string IdBien { get; set; }
        public int IdCategorieBien { get; set; }
        public int IdBienSeq { get; set; }
        public string DesigBien { get; set; }
        public DateTime DateAcquisitionBien { get; set; }
        public string personne { get; set; }
        public double Prix { get; set; }
        public string Photo { get; set; }
        public string ancienCode { get; set; }
        public int idFournisseur { get; set; }
        public string Marque { get; set; }
        public string numSerie { get; set; }
        public string Fournisseur { get; set; }
        public string etat { get; set; }
        public DateTime DateMiseService { get; set; }
        public string natureBien { get; set; }
        public int idUtilisateur { get; set; }
        public string Model { get; set; }
        public string ancienCodeBarre { get; set; }
        public string dernierEmplacement { get; set; }
        public bool réetiqueter { get; set; }
        public string idBienMobil { get; set; }
        public int idEmploye { get; set; }
        public int idSociete { get; set; }
        public string ficheImmobilisation { get; set; }
        public string codeAmortissement { get; set; }
        public string datecession { get; set; }
        public string datederniereaffectation { get; set; }

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