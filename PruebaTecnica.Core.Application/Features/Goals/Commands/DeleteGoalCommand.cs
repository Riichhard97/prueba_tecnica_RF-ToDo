using MediatR;

namespace PruebaTecnica.Core.Application.Features.Goals.Commands
{
    public class DeleteGoalCommand : IRequest<Unit>
    {
        public int Id { get; set; }
    }
}
