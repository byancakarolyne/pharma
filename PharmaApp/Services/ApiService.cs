using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Collections.Generic;
using PharmaAPI.Domain.Entities;
using PharmaApp.Components.Pages;

namespace PharmaApp.Services
{
    public class ApiService
    {
        private readonly HttpClient _httpClient;

        // Construtor que recebe o HttpClient, que será injetado
        public ApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        // Método para adicionar medicamento
        public async Task<MedicamentoDto> AdicionarMedicamentoAsync(MedicamentoDto medicamento)
        {
            var response = await _httpClient.PostAsJsonAsync("http://localhost:5053/api/medicamento", medicamento);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<MedicamentoDto>();
            }
            else
            {
                // Tratar erro, talvez lançar uma exceção ou retornar null
                return null;
            }
        }
        public async Task<List<MedicamentoDto>> GetMedicamentosAsync()
        {
            var response = await _httpClient.GetFromJsonAsync<List<MedicamentoDto>>("http://localhost:5053/api/medicamento");

            return response ?? new List<MedicamentoDto>();
        }
    }
}
