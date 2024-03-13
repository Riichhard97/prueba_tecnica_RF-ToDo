using MediatR;

namespace PruebaTecnica.Core.Application.Features.Goals.Commands
{
    public class UpdateGoalCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
