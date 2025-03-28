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

        public ApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<MedicamentoDto> AdicionarMedicamentoAsync(MedicamentoDto medicamento)
        {
            var response = await _httpClient.PostAsJsonAsync("api/medicamento", medicamento);

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
            var response = await _httpClient.GetFromJsonAsync<List<MedicamentoDto>>("api/medicamento");

            return response ?? new List<MedicamentoDto>();
        }
    }
}
