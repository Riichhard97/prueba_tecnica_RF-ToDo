using AutoMapper;
using MediatR;
using PruebaTecnica.Core.Application.Features.Goals.Commands;
using PruebaTecnica.Core.Domain.Entities;
using PruebaTecnica.Core.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnica.Core.Application.Features.Activities.Commands
{
    internal class AddActivityCommandHandler : IRequestHandler<AddActivityCommand, Unit>
    {
        private readonly CoreDbContext _context;
        public AddActivityCommandHandler(CoreDbContext context)
        {
            _context = context;
        }


        public async Task<Unit> Handle(AddActivityCommand request, CancellationToken cancellationToken)
        {
            await _context.Activity.AddAsync(new Activity() { Name = request.Name, Important = false, Completed = false, GoalId = request.GoalId });

            await _context.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
