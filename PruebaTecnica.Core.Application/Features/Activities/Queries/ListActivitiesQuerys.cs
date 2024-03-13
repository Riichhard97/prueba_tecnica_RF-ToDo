using MediatR;
using PruebaTecnica.Shared.Dtos;

namespace PruebaTecnica.Core.Application.Features.Activities.Queries
{
    public class ListActivitiesQuerys : IRequest<List<ActivityDto>>
    {
    }
}
