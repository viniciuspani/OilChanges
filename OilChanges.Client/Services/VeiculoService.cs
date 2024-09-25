
using System.Collections;
using System.Net.Http;
using System.Net;
using OilChanges.Shared.DTOs;
using System.Net.Http.Json;

namespace OilChanges.Client.Services
{
    public class VeiculoService : IVeiculoService
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseUrl = "api/veiculos";

        public VeiculoService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<VeiculoDTO>> GetVeiculosFabricantes(string marca)
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<VeiculoDTO>>($"{_baseUrl}/fabricantes/{marca}");
        }

        public async Task<List<VeiculoDTO>> GetVeiculos()
        {
            //return await _httpClient.GetFromJsonAsync<IEnumerable<VeiculoDTO>>(_baseUrl);
            var response = await _httpClient.GetAsync(_baseUrl + "/listaVeiculos");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<List<VeiculoDTO>>();
        }

        public async Task<VeiculoDTO> GetVeiculo(int id)
        {
            return await _httpClient.GetFromJsonAsync<VeiculoDTO>($"{_baseUrl}/{id}");
        }

        public async Task<VeiculoDTO> CreateVeiculo(VeiculoDTO veiculo)
        {
            var response = await _httpClient.PostAsJsonAsync(_baseUrl, veiculo);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<VeiculoDTO>();
        }

        public async Task<VeiculoDTO> UpdateVeiculo(int id, VeiculoDTO veiculo)
        {
            var response = await _httpClient.PutAsJsonAsync($"{_baseUrl}/{id}", veiculo);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<VeiculoDTO>();
        }

        public async Task DeleteVeiculo(int id)
        {
            var response = await _httpClient.DeleteAsync($"{_baseUrl}/{id}");
            response.EnsureSuccessStatusCode();
        }

    }
}
