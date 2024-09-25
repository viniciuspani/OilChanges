using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OilChanges.Shared.Model
{
    public class Oleo
    {
        [Key]
        public int OleoId { get; set; }

        [StringLength(100)]
        [Required(ErrorMessage = "Informe o nome do oleo.")]
        [Display(Name = "Nome do Oleo")]
        public string Nome { get; set; }


        [StringLength(80)]
        [Required(ErrorMessage = "Informe o tipo de oleo.")]
        [Display(Name = "Tipo do Oleo")]
        public string TipoOleo { get; set; }

        //public int VeiculoId { get; set; }

        public virtual List<TrocaOleo> TrocaOleos { get; set; }
    }
}
