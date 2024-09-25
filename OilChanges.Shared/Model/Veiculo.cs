using System.ComponentModel.DataAnnotations;

namespace OilChanges.Shared.Model
{
    public class Veiculo
    {
        [Key]
        public int VeiculoId { get; set; }


        //[StringLength(80, MinimumLength = 10, ErrorMessage = "O {0} deve ter no minimo {1} e no maximo {2}.")]
        [Required(ErrorMessage = "Informe o nome do veiculo.")]
        [Display(Name = "Nome do veiculo")]
        public string? Modelo { get; set; }

        //[StringLength(80, MinimumLength = 10, ErrorMessage = "O {0} deve ter no minimo {1} e no maximo {2}.")]
        [Required(ErrorMessage = "Informe o fabricante do veiculo.")]
        [Display(Name = "Fabricante do veiculo")]
        public string? Fabricante { get; set; }


        [Required(ErrorMessage = "Informe o ano de fabricação do veiculo.")]
        [Range(-0, int.MaxValue)]
        [Display(Name = "Ano de fabricação")]
        public int? AnoFabricacao { get; set; }                  

        //[StringLength(80, MinimumLength = 5, ErrorMessage = "O {0} deve ter no minimo {2} e no maximo {1}.")]
        [Required(ErrorMessage = "Informe a placa do veiculo.")]
        [Display(Name = "Placa Veiculo")]
        public string? Placa { get; set; }

        [Required(ErrorMessage = "Informe a placa do veiculo.")]
        [Display(Name = "Renavam Veiculo")]
        public string? Renavam { get; set; }

        public virtual List<TrocaOleo>? TrocaOleos { get; set; }

        
    }
}
