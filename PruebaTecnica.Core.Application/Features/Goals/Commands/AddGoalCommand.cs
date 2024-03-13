using MediatR;

namespace PruebaTecnica.Core.Application.Features.Goals.Commands
{
    public class AddGoalCommand : IRequest<Unit>
    {
        public string Name { get; set; }
    }
}
