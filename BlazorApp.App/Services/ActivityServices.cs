using MediatR;
using PruebaTecnica.Shared.Dtos;
using PruebaTecnica.Shared.RequestModels.Acitivity;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text;
using PruebaTecnica.Shared.RequestModels;
using CurrieTechnologies.Razor.SweetAlert2;
using static System.Net.Mime.MediaTypeNames;
using PruebaTecnica.Shared.Dtos.Common;

namespace BlazorApp.App.Services
{
    public class ActivityServices : IActivityServices
    {
        private readonly HttpClient _httpClient;
        private readonly SweetAlertService _sweetAlertService;

        public ActivityServices(HttpClient httpClient, SweetAlertService sweetAlertService)
        {
            _httpClient = httpClient;
            _sweetAlertService = sweetAlertService;
        }

        public async Task<Unit> Add(AddActivityRequestModel query)
        {
          
            var response = await _httpClient.PostAsJsonAsync("/api/Activity", query);
            var responseData = await response.Content.ReadFromJsonAsync<ApiResponse<Unit>>();

            if (!responseData.Success)
            {
                await ShowAlert(responseData.Message);
            }
         
            return Unit.Value;
        }

        public async Task<List<ActivityDto>> GetAll()
        {
            var response = await _httpClient.GetFromJsonAsync<ApiResponse<List<ActivityDto>>>("/api/Activity");
            if (!response.Success)
            {
                await ShowAlert(response.Message);
            }
            return response.Data;
        }

        public async Task<PaginationResponseModel<ActivityDto>> GetAllByGoalId(ListActivitiesByGoalRequestModel request)
        {
            var response = await _httpClient.PostAsJsonAsync("/api/Activity/GetAllByGoalId", request);
            response.EnsureSuccessStatusCode();

            var responseData = await response.Content.ReadFromJsonAsync<ApiResponse<PaginationResponseModel<ActivityDto>>>();

            if (!responseData.Success)
            {
                await ShowAlert(responseData.Message);
            }

            return responseData.Data;
        }

        public async Task<Unit> DeleteList(DeleteActivitiesRequestModel query)
        {

            var request = new HttpRequestMessage(HttpMethod.Delete, "/api/Activity/DeleteList");
            request.Content = new StringContent(JsonSerializer.Serialize(query), Encoding.UTF8, "application/json");
            var response = await _httpClient.SendAsync(request);
            var responseData = await response.Content.ReadFromJsonAsync<ApiResponse<Unit>>();
            if (!responseData.Success)
            {
                await ShowAlert(responseData.Message);
            }

            return responseData.Data;
        }

        public async Task<Unit> SetCompleteActivities(SetCompleteActivitiesRequestModel query)
        {
            var response = await _httpClient.PutAsJsonAsync("/api/Activity/SetCompleteActivities", query);
            var responseData = await response.Content.ReadFromJsonAsync<ApiResponse<Unit>>();

            if (!responseData.Success)
            {
                await ShowAlert(responseData.Message);
            }

            return responseData.Data;
        }

        public async Task<Unit> Update(int id, UpdateActivityRequestModel query)
        {
            var response = await _httpClient.PutAsJsonAsync($"/api/Activity/{id}", query);
            var responseData = await response.Content.ReadFromJsonAsync<ApiResponse<Unit>>();

            if (!responseData.Success)
            {
                await ShowAlert(responseData.Message);
            }

            return responseData.Data;
        }

        private async Task ShowAlert(string message)
        {
            await _sweetAlertService.FireAsync(new SweetAlertOptions
            {
                Title = "Advertencia",
                Text = message,
                Icon = SweetAlertIcon.Warning,
                ConfirmButtonText = "Aceptar",
                ConfirmButtonColor = "rgb(51, 102, 102)"
            });
            throw new Exception(message);
        }
    }
}
