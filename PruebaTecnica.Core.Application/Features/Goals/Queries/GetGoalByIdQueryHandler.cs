using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PruebaTecnica.Core.Application.Contracts;
using PruebaTecnica.Core.Persistence;
using PruebaTecnica.Shared.Dtos;

namespace PruebaTecnica.Core.Application.Features.Goals.Queries
{
    public class GetGoalByIdQueryHandler : IQueryHandler<GetGoalByIdQuery, GoalDto>
    {
        private readonly CoreDbContext _context;
        private readonly IMapper _mapper;
        public GetGoalByIdQueryHandler(CoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<GoalDto> Handle(GetGoalByIdQuery request, CancellationToken cancellationToken)
        {
            var obj = await _context.Goal.Include(goal=>goal.Activities).FirstOrDefaultAsync((obj) => obj.Id == request.Id);
            var objDto = _mapper.Map<GoalDto>(obj);

            return objDto;
        }
    }
}
