//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré à partir d'un modèle.
//
//     Des modifications manuelles apportées à ce fichier peuvent conduire à un comportement inattendu de votre application.
//     Les modifications manuelles apportées à ce fichier sont remplacées si le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GestionCabinetAvocat.DAO
{
    using System;
    using System.Collections.Generic;
    
    public partial class Adherent
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Adresse { get; set; }
        public string Adresse2 { get; set; }
        public string Tel { get; set; }
        public string Email { get; set; }
        public System.DateTime DateNaissance { get; set; }
        public System.DateTime DateCreation { get; set; }
        public string Description { get; set; }
        public int IdCompte { get; set; }
        public int IdDossier { get; set; }
        public string Etat { get; set; }
    
        public virtual Compte Compte { get; set; }
        public virtual Dossier Dossier { get; set; }
    }
}
