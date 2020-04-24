using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LO.MyAirport.EF
{
    /// <summary>
    /// Classe Vol, représente une instance de Vol
    /// </summary>
    public class Vol
    {
        /// <summary>
        /// Clé Primaire de ma class Vol
        /// </summary>
        public int? VolId { get; set; }
        /// <summary>
        /// Compagnie du vol
        /// </summary>
        [Display(Name = "Compagnie")]
        public string Cie { get; set; }
        /// <summary>
        /// Ligne du vol
        /// </summary>
        [Display(Name = "Ligne du vol")]
        public string Lig { get; set; }
        /// <summary>
        /// Dernier horaire connu, horaire de départ du vol
        /// </summary>
        [Display(Name = "Horaire de départ du vol")]
        public DateTime Dhc { get; set; }
        /// <summary>
        /// Parking affecté au vol
        /// </summary>
        [Display(Name = "Parking affecté au vol")]
        public string? Pkg { get; set; }
        /// <summary>
        /// N° immatriculation de l'avion
        /// </summary>
        [Display(Name = "N° immatriculation de l'avion")]
        public string? Imm { get; set; }
        /// <summary>
        /// Nombre de passager du vol
        /// </summary>
        [Display(Name = "Nombre de passager du vol")]
        public int? Pax { get; set; }
        /// <summary>
        /// Destination finale du vol
        /// </summary>
        [Display(Name = "Destination finale du vol")]
        public string? Des { get; set; }
        /// <summary>
        /// Propriété de naviguation
        /// </summary>
        public IEnumerable<Bagage>? Bagages { get; set; }


        /// <summary>
        /// Constructeur d'une instance de vol
        /// </summary>
        /// <param name="compagnie"></param>
        /// <param name="ligne"></param>
        /// <param name="dhc"></param>
        public Vol(string compagnie, string ligne, DateTime dhc)
        {
            Cie = compagnie;
            Lig = ligne;
            Dhc = dhc;
            Bagages = new List<Bagage>();
        }

        public Vol()
        {
        }


    }
}
