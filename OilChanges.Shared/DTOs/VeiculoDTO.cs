using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OilChanges.Shared.DTOs
{
    public class VeiculoDTO
    {
        public int VeiculoId { get; set; }
        [Required]
        public string? Modelo { get; set; }
        [Required]
        public string? Fabricante { get; set; }
        [Required]
        public int? AnoFabricacao { get; set; }
        [Required]
        public string? Placa { get; set; }
        [Required]
        public string? Renavam { get; set; }
    }
}
