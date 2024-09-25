using OilChanges.Shared.DTOs;
using OilChanges.Shared.Model;
using System.Net.Http.Json;

namespace OilChanges.Client.Services
{
    public class OleoService : IOleoService
    {

        private readonly HttpClient _httpClient;
        private readonly string _baseUrl = "api/oleos";

        public OleoService(HttpClient httpClient)
        {
            _httpClient = httpClient;            
        }

        public async Task<OleoDTO> GetOleo(int id)
        {
            return await _httpClient.GetFromJsonAsync<OleoDTO>($"{_baseUrl}/{id}");
        }

        public async Task<List<OleoDTO>> GetOleos()
        {
            var response = await _httpClient.GetAsync(_baseUrl + "/listaOleos");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<List<OleoDTO>>();
        }

        public async Task<OleoDTO> CreateOleo(OleoDTO oleo)
        {
            var response = await _httpClient.PostAsJsonAsync(_baseUrl, oleo);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<OleoDTO>();
        }
        public async Task<OleoDTO> UpdateOleo(int id, OleoDTO oleo)
        {
            var response = await _httpClient.PutAsJsonAsync($"{_baseUrl}/{id}", oleo);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<OleoDTO>();
        }

        public async Task DeleteOleo(int id)
        {
            var response = await _httpClient.DeleteAsync($"{_baseUrl}/{id}");
            response.EnsureSuccessStatusCode();
        }
    }
}
