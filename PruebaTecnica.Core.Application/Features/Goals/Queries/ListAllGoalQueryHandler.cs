using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PruebaTecnica.Core.Application.Contracts;
using PruebaTecnica.Core.Persistence;
using PruebaTecnica.Shared.Dtos;

namespace PruebaTecnica.Core.Application.Features.Goals.Queries
{
    public class ListAllGoalQueryHandler : IQueryHandler<ListAllGoalQuery, List<GoalDto>>
    {
        private readonly CoreDbContext _context;
        private readonly IMapper _mapper;
        public ListAllGoalQueryHandler(CoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<GoalDto>> Handle(ListAllGoalQuery request, CancellationToken cancellationToken)
        {
            var obj = await _context.Goal.Include(goal=>goal.Activities).ToListAsync();
            var objDto = _mapper.Map<List<GoalDto>>(obj);

            return objDto;
        }
    }
}
