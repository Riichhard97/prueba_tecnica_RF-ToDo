using MediatR;
using PruebaTecnica.Core.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnica.Core.Application.Features.Activities.Commands
{
    internal class SetCompleteActivitiesCommandHandler : IRequestHandler<SetCompleteActivitiesCommand, Unit>
    {
        private readonly CoreDbContext _context;
        public SetCompleteActivitiesCommandHandler(CoreDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(SetCompleteActivitiesCommand request, CancellationToken cancellationToken)
        {

            using (var transaction = await _context.Database.BeginTransactionAsync())
            {
                try
                {
                    var activities = _context.Activity.Where((activity) => request.Ids.Contains(activity.Id.Value));

                    foreach (var item in activities)
                    {
                        item.Completed = request.isComplete;
                    }

                    await _context.SaveChangesAsync();
                    await transaction.CommitAsync();

                }
                catch (Exception)
                {
                    await transaction.RollbackAsync();
                    throw; 
                }
            }

            return Unit.Value;
        }
    }
}
