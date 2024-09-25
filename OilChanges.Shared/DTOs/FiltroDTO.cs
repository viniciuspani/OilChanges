using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OilChanges.Shared.DTOs
{
    public class FiltroDTO
    {
        [Key]
        public int FiltroId { get; set; }
        [Required(ErrorMessage = "Informe a marca do filtro.")]
        [Display(Name = "Marca do Filtro")]
        public string Marca { get; set; }
        [Required(ErrorMessage = "Informe a modelo do filtro.")]
        [Display(Name = "Modelo do Filtro")]
        public string Modelo { get; set; }
        [Required(ErrorMessage = "Informe a tipo do filtro.")]
        [Display(Name = "Tipo do Filtro")]
        public string Tipo { get; set; }                
        public DateTime DataDeFabricacao { get; set; }
        public DateTime DataDeValidade { get; set; }
             
    }
}
