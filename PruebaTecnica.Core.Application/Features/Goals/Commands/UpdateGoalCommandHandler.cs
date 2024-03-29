﻿using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PruebaTecnica.Core.Domain.Entities;
using PruebaTecnica.Core.Persistence;

namespace PruebaTecnica.Core.Application.Features.Goals.Commands
{
    public class UpdateGoalCommandHandler : IRequestHandler<UpdateGoalCommand, Unit>
    {
        private readonly CoreDbContext _context;
        private readonly IMapper _mapper;
        public UpdateGoalCommandHandler(CoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        public async Task<Unit> Handle(UpdateGoalCommand request, CancellationToken cancellationToken)
        {
            var someWithSameName = await _context.Goal.AnyAsync(Goal => Goal.Name == request.Name && Goal.Id != request.Id);
            if (someWithSameName)
                throw new Exception("El nombre de la meta ya existe.");
            
            var goal = await _context.Goal.FirstOrDefaultAsync<Goal>((obj) => obj.Id == request.Id);
            goal.Name = request.Name;

            await _context.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
