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
    
    public partial class Piece
    {
        public int Id { get; set; }
        public string Descreption { get; set; }
        public string path { get; set; }
        public int IdProcedure { get; set; }
    
        public virtual ProcedureJuridique ProcedureJuridique { get; set; }
    }
}
