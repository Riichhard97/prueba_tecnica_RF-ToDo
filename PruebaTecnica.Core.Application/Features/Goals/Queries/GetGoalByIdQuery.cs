using PruebaTecnica.Core.Application.Contracts;
using PruebaTecnica.Shared.Dtos;

namespace PruebaTecnica.Core.Application.Features.Goals.Queries
{
    public class GetGoalByIdQuery : IQuery<GoalDto>
    {
        public int Id { get; set; }
    }
}
