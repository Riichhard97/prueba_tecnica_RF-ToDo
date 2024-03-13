using MediatR;
using Microsoft.EntityFrameworkCore;
using PruebaTecnica.Core.Persistence;

namespace PruebaTecnica.Core.Application.Features.Activities.Commands
{
    public class UpdateActivityCommandHandler : IRequestHandler<UpdateActivityCommand, Unit>
    {
        private readonly CoreDbContext _context;
        public UpdateActivityCommandHandler(CoreDbContext context)
        {
            _context = context;
        }


        public async Task<Unit> Handle(UpdateActivityCommand request, CancellationToken cancellationToken)
        {
            var obj = await _context.Activity.FirstOrDefaultAsync((obj) => obj.Id == request.Id);

            if(request.Name != null)
                obj.Name = request.Name;

            if (request.Important.HasValue)
                obj.Important = request.Important.Value;

            await _context.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
