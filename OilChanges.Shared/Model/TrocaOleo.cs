using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OilChanges.Shared.Model
{
    public class TrocaOleo
    {
        [Key]
        public int TrocaOleoId { get; set; }

        public int VeiculoId { get; set; }
        public Veiculo Veiculo { get; set; }  // Propriedade de navegação
        public int OleoId { get; set; }
        public Oleo Oleo { get; set; }  // Propriedade de navegação
        public int FiltroId { get; set; }
        public Filtro Filtro { get; set; }  // Propriedade de navegação

        [Column(TypeName = "decimal(18,2)")]
        [Required(ErrorMessage = "Informe a quilometragem atual.")]
        public double KmAtual { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        [Required(ErrorMessage = "Informe a quilometragem da proxima troca.")]
        public double KmProximaTroca { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        [Display(Name = "Quantidade de litro de oleo")]
        public double QuantidadeOleo { get; set; }

        [Required(ErrorMessage = "Informe a data da troca de oleo.")]
        public DateTime DataTroca = DateTime.Now;

        //Fazer validação para a dataProximaTroca seja maior que a DataTroca
        public DateTime? DataProximaTroca { get; set; }

        public override string ToString()
        {
            return $"TrocaOleoId: {TrocaOleoId}, Veiculo: {Veiculo.Modelo}, Oleo: {Oleo.Nome}, Filtro: {Filtro.Modelo}, Data da Troca: {DataTroca}";
        }
    }
}
