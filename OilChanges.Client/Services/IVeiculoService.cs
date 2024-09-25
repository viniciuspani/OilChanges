

using OilChanges.Shared.DTOs;

namespace OilChanges.Client.Services
{
    public interface IVeiculoService
    {
        Task<IEnumerable<VeiculoDTO>> GetVeiculosFabricantes(string marca);
        Task<List<VeiculoDTO>> GetVeiculos();
        Task<VeiculoDTO> GetVeiculo(int id);
        Task<VeiculoDTO> CreateVeiculo(VeiculoDTO veiculo);
        Task<VeiculoDTO> UpdateVeiculo(int id, VeiculoDTO veiculo);
        Task DeleteVeiculo(int id);
    }
}
