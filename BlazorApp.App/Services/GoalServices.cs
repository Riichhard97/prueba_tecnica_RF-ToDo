using MediatR;
using PruebaTecnica.Shared.Dtos;
using PruebaTecnica.Shared.RequestModels.Goal;
using System.Net.Http.Json;
using CurrieTechnologies.Razor.SweetAlert2;
using PruebaTecnica.Shared.Dtos.Common;
using PruebaTecnica.Shared.RequestModels;

namespace BlazorApp.App.Services
{
    public class GoalServices : IGoalServices
    {
        public string ServiceName = "goal";
        private readonly HttpClient _httpClient;
        private readonly SweetAlertService _sweetAlertService;

        public GoalServices(HttpClient httpClient, SweetAlertService sweetAlertService)
        {
            _httpClient = httpClient;
            _sweetAlertService = sweetAlertService;
        }

        public async Task<PaginationResponseModel<GoalDto>> GetAll(PaginationRequestModel paginationRequestModel)
        {
            var response = await _httpClient.GetFromJsonAsync<ApiResponse<PaginationResponseModel<GoalDto>>>("/api/" + ServiceName+$"?Page={paginationRequestModel.Page}&PageSize={paginationRequestModel.PageSize}");

            if (!response.Success)
            {
                await ShowAlert(response.Message);
                return new PaginationResponseModel<GoalDto>();
            }

            return response.Data;
        }

        public async Task<GoalDto> GetById(int Id)
        {
            var response = await _httpClient.GetFromJsonAsync<ApiResponse<GoalDto>>($"/api/{ServiceName}/{Id}");

            if (!response.Success)
            {
                await ShowAlert(response.Message);
                return null;
            }
                
            return response.Data;
        }

        public async Task<Unit> Add(GoalRequestModel query)
        {
            var response = await _httpClient.PostAsJsonAsync("api/goal", query);
            var responseData = await response.Content.ReadFromJsonAsync<ApiResponse<Unit>>();

            if (!responseData.Success)
            {
                await ShowAlert(responseData.Message);
                return Unit.Value;
            }

            return responseData.Data;
        }

        public async Task<Unit> Update(int id, GoalRequestModel query)
        {
            var response = await _httpClient.PutAsJsonAsync($"api/goal/{id}", query);
            var responseData = await response.Content.ReadFromJsonAsync<ApiResponse<Unit>>();

            if (!responseData.Success)
            {
                await ShowAlert(responseData.Message);
                return Unit.Value;
            }

            return responseData.Data;
        }

        public async Task<Unit> Delete(int id)
        {
            var response = await _httpClient.DeleteAsync($"api/goal/{id}");
            var responseData = await response.Content.ReadFromJsonAsync<ApiResponse<Unit>>();

            if (!responseData.Success)
            {
                await ShowAlert(responseData.Message);
                return Unit.Value;
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
