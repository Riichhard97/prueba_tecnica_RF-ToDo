using MediatR;
using PruebaTecnica.Shared.Dtos;
using PruebaTecnica.Shared.RequestModels.Acitivity;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text;

namespace BlazorApp.App.Services
{
    public class ActivityServices : IActivityServices
    {
        private readonly HttpClient _httpClient;

        public ActivityServices(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Unit> Add(AddActivityRequestModel query)
        {
            await _httpClient.PostAsJsonAsync("/api/Activity", query);
            return Unit.Value;
        }

        public async Task<Unit> DeleteList(DeleteActivitiesRequestModel query)
        {
            var request = new HttpRequestMessage(HttpMethod.Delete, "/api/Activity/DeleteList");
            request.Content = new StringContent(JsonSerializer.Serialize(query), Encoding.UTF8, "application/json");
            await _httpClient.SendAsync(request);
            return Unit.Value;
        }

        public async Task<List<ActivityDto>> GetAll()
        {
            return await _httpClient.GetFromJsonAsync<List<ActivityDto>>("/api/Activity");
        }

        public async Task<Unit> SetCompleteActivities(SetCompleteActivitiesRequestModel query)
        {
            await _httpClient.PutAsJsonAsync("/api/Activity/SetCompleteActivities", query);
            return Unit.Value;

        }

        public async Task<Unit> Update(int id, UpdateActivityRequestModel query)
        {
            await _httpClient.PutAsJsonAsync($"/api/Activity/{id}", query);
            return Unit.Value;

        }
    }
}
