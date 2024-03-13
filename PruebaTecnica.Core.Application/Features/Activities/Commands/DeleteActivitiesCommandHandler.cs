using MediatR;
using Microsoft.EntityFrameworkCore;
using PruebaTecnica.Core.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnica.Core.Application.Features.Activities.Commands
{
    public class DeleteActivitiesCommandHandler : IRequestHandler<DeleteActivitiesCommand, Unit>
    {
        public CoreDbContext _context { get; }

        public DeleteActivitiesCommandHandler(CoreDbContext coreDbContext)
        {
            _context = coreDbContext;
        }


        public async Task<Unit> Handle(DeleteActivitiesCommand request, CancellationToken cancellationToken)
        {
            using (var transaction = await _context.Database.BeginTransactionAsync())
            {
                try
                {
                    var activities = _context.Activity.Where((activity) => request.Ids.Contains(activity.Id.Value));

                    _context.RemoveRange(activities);

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
