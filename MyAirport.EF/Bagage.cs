using System;
using System.ComponentModel.DataAnnotations;

namespace LO.MyAirport.EF
{
    public class Bagage
    {
        /// <summary>
        /// Identifiant du bagage
        /// </summary>
        public int BagageId { get; set; }
        /// <summary> 
        /// Propriété de naviguate
        /// </summary>
        public virtual Vol? Vol { get; set; }
        /// <summary>
        /// Identifiant du vol associé au bagage
        /// </summary>
        [Display(Name = "ID du vol")]
        public int? VolId { get; set; }
        /// <summary>
        /// Date d'ajout du bagage
        /// </summary>
        [Display(Name = "Date de creation")]
        public DateTime DateCreation { get; set; }
        /// <summary>
        /// Code Iata de la compagnie associée au bagage
        /// </summary>
        [StringLength(16)]
        [Display(Name = "Code IATA")]
        public string CodeIata { get; set; }
        /// <summary>
        /// Classe associé au bagage
        /// </summary>
        public string? Classe { get; set; }
        /// <summary>
        /// Propriétaire du bagage
        /// </summary>
        public bool? Prioritaire { get; set; }
        /// <summary>
        /// Status du bagage
        /// </summary>
        [Display(Name = "Status du bagage")]
        public string? Sta { get; set; }
        /// <summary>
        /// Status de sureté du bagage
        /// </summary>
        [Display(Name = "Status de sureté du bagage")]
        public string? Ssur { get; set; }
        /// <summary>
        /// Destination finale du vol associé au bagage
        /// </summary>
        public string? Destination { get; set; }
        /// <summary>
        /// Escales par lesquelles va circuler le bagage
        /// </summary>
        public string? Escale { get; set; }
           
        /// <summary>
        /// Constructeur d'une instance de bagage
        /// </summary>
        /// <param name="codeIata">Code Iata du vol associé à associer au bagage</param>
        /// <param name="dateCreation">Date d'ajout du bagage</param>
        public Bagage(string codeIata, DateTime dateCreation)
        {
            CodeIata = codeIata;
            DateCreation = dateCreation;
        }
        public Bagage()
        {

        }
    }
}
