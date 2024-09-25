using OilChanges.Shared.DTOs;

namespace OilChanges.Client.Services
{
    public interface IOleoService
    {
        
        Task<List<OleoDTO>> GetOleos();
        Task<OleoDTO> GetOleo(int id);
        Task<OleoDTO> CreateOleo(OleoDTO oleo);
        Task<OleoDTO> UpdateOleo(int id, OleoDTO oleo);
        Task DeleteOleo(int id);
    }
}
