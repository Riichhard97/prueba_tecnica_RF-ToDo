using AutoMapper;
using MediatR;
using PruebaTecnica.Core.Domain.Entities;
using PruebaTecnica.Core.Persistence;

namespace PruebaTecnica.Core.Application.Features.Goals.Commands
{
    public class AddGoalCommandHandler : IRequestHandler<AddGoalCommand, Unit>
    {
        private readonly CoreDbContext _context;
        private readonly IMapper _mapper;
        public AddGoalCommandHandler(CoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        public async Task<Unit> Handle(AddGoalCommand request, CancellationToken cancellationToken)
        {
            var obj = await _context.Goal.AddAsync(new Goal() { Name = request.Name});

            await _context.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
