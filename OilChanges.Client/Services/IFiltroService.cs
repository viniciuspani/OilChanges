using OilChanges.Shared.DTOs;

namespace OilChanges.Client.Services
{
    public interface IFiltroService
    {
        Task<List<FiltroDTO>> GetFiltros();
        Task<FiltroDTO> GetFiltro(int id);
        Task<FiltroDTO> CreateFiltro(FiltroDTO filtro);
        Task<FiltroDTO> UpdateFiltro(int id, FiltroDTO filtro);
        Task DeleteFiltro(int id);
    }
}
