using MediatR;
using PruebaTecnica.Shared.Dtos;
using PruebaTecnica.Shared.RequestModels;
using PruebaTecnica.Shared.RequestModels.Goal;

namespace BlazorApp.App.Services
{
    public interface IGoalServices
    {
        Task<PaginationResponseModel<GoalDto>> GetAll(PaginationRequestModel paginationRequestModel);
        Task<GoalDto> GetById(int Id);
        Task<Unit> Add(GoalRequestModel query);
        Task<Unit> Update(int id, GoalRequestModel query);
        Task<Unit> Delete(int id);
    }
}
