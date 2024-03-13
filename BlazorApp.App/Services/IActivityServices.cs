﻿using MediatR;
using PruebaTecnica.Shared.Dtos;
using PruebaTecnica.Shared.RequestModels.Acitivity;

namespace BlazorApp.App.Services
{
    public interface IActivityServices
    {
        Task<List<ActivityDto>> GetAll();
        Task<Unit> Update(int id, UpdateActivityRequestModel query);
        Task<Unit> SetCompleteActivities( SetCompleteActivitiesRequestModel query);
        Task<Unit> Add(AddActivityRequestModel query);
        Task<Unit> DeleteList(DeleteActivitiesRequestModel query);
    }
}
