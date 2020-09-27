using AmimirMVC.CustomValidations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace AmimirMVC.Models
{
    public class AnimeCLS
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "Escriba un nombre para el anime")]
        [StringLength(100, ErrorMessage = "100 caracteres máx.")]
        public string Nombre { get; set; }
        [Display(Name="Fecha de Estreno")]
        public string FechaEstreno { get; set; }
        [Display(Name="ID Secuela")]
        public int? SecuelaID { get; set; }
        public string Secuela { get; set; }
        [Display(Name="ID Precuela")]
        public int? PrecuelaID { get; set; }
        public string Precuela { get; set; }
        [Required(ErrorMessage = "Escriba una sinopsis para el anime")]
        [StringLength(400, ErrorMessage = "400 caracteres máx.")]
        public string Sinopsis { get; set; }
        [Display(Name="Puntuación")]
        [Required(ErrorMessage = "Escriba una puntuación para el anime")]
        [Range(1, 5, ErrorMessage = "Valor debe de ser entre 1 a 5")]
        [RegularExpression(@"^\d(\.\d{1,2})?$", ErrorMessage = "Número debe de ser entre 1 a 5 y tener dos decimales máximo")]
        public Decimal Puntuacion { get; set; }
        [Required(ErrorMessage = "Escriba la popularidad del anime")]
        [Range(1, 5, ErrorMessage = "Valor debe de ser entre 1 a 5")]
        [RegularExpression(@"^\d(\.\d{1,2})?$", ErrorMessage = "Número debe de ser entre 1 a 5 y tener dos decimales máximo")]
        public Decimal Popularidad { get; set; }
        [Display(Name="ID Estado")]
        [Required(ErrorMessage = "Seleccione un estado para el anime")]
        public int EstadoID { get; set; }
        public string Estado { get; set; }
    }

    public class AnimeViewCLS : AnimeCLS
    {
        public List<EstadoCLS> ListaEstado { get; set; }
        public List<AnimeCLS> ListaAnime { get; set; }

    }
}