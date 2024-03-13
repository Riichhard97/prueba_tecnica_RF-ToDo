using MediatR;
using PruebaTecnica.Shared.Dtos;
using PruebaTecnica.Shared.RequestModels.Goal;
using System.Net.Http.Json;

namespace BlazorApp.App.Services
{
    public class GoalServices : IGoalServices
    {

        public string ServiceName = "goal";
        private readonly HttpClient _httpClient;

        public GoalServices(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<List<GoalDto>> GetAll()
        {
            var result = await _httpClient.GetFromJsonAsync<List<GoalDto>>("/api/"+ ServiceName);
            return result;
        }

        public async Task<GoalDto> GetById(int Id)
        {
            var result = await _httpClient.GetFromJsonAsync<GoalDto>($"/api/{ServiceName}/{Id}");
            return result;
        }

        public async Task<Unit> Add(GoalRequestModel query)
        {
            var response = await _httpClient.PostAsJsonAsync("api/goal", query);
            response.EnsureSuccessStatusCode();
            return Unit.Value;
        }

        public async Task<Unit> Update(int id, GoalRequestModel query)
        {
            var response = await _httpClient.PutAsJsonAsync($"api/goal/{id}", query);
            response.EnsureSuccessStatusCode();
            return Unit.Value;
        }

        public async Task<Unit> Delete(int id)
        {
            var response = await _httpClient.DeleteAsync($"api/goal/{id}");
            response.EnsureSuccessStatusCode();
            return Unit.Value;
        }
    }
}
