using OilChanges.Shared.DTOs;
using OilChanges.Shared.Model;
using System.Net.Http.Json;

namespace OilChanges.Client.Services
{
    public class FiltroService : IFiltroService
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseUrl = "api/filtros";

        public FiltroService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        

        public async Task<FiltroDTO> GetFiltro(int id)
        {
            return await _httpClient.GetFromJsonAsync<FiltroDTO>($"{_baseUrl}/{id}");
        }

        public async Task<List<FiltroDTO>> GetFiltros()
        {
            var response = await _httpClient.GetAsync(_baseUrl + "/listaFiltros");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<List<FiltroDTO>>();
        }

        public async Task<FiltroDTO> CreateFiltro(FiltroDTO filtro)
        {
            var response = await _httpClient.PostAsJsonAsync(_baseUrl, filtro);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<FiltroDTO>();
        }

        public async Task<FiltroDTO> UpdateFiltro(int id, FiltroDTO filtro)
        {
            var response = await _httpClient.PutAsJsonAsync($"{_baseUrl}/{id}", filtro);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<FiltroDTO>();
        }

        public async Task DeleteFiltro(int id)
        {
            var response = await _httpClient.DeleteAsync($"{_baseUrl}/{id}");
            response.EnsureSuccessStatusCode();
        }                     
    }
}
