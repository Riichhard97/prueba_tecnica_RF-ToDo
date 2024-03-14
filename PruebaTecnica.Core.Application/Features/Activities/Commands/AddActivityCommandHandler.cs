using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
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
            var someWithSameName = await _context.Activity.AnyAsync(Activity => Activity.Name == request.Name && Activity.GoalId == request.GoalId);
            if (someWithSameName)
                throw new Exception("El nombre de la actividad ya existe.");

            await _context.Activity.AddAsync(new Activity() { Name = request.Name, Important = false, Completed = false, GoalId = request.GoalId });

            await _context.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
