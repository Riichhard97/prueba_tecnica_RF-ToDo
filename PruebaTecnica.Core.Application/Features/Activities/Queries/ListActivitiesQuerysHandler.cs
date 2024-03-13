using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PruebaTecnica.Core.Persistence;
using PruebaTecnica.Shared.Dtos;

namespace PruebaTecnica.Core.Application.Features.Activities.Queries
{
    public class ListActivitiesQuerysHandler : IRequestHandler<ListActivitiesQuerys, List<ActivityDto>>
    {
        private readonly CoreDbContext _context;
        private readonly IMapper _mapper;
        public ListActivitiesQuerysHandler(CoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<ActivityDto>> Handle(ListActivitiesQuerys request, CancellationToken cancellationToken)
        {
            var obj = await _context.Activity.ToListAsync();
            var objDto = _mapper.Map<List<ActivityDto>>(obj);

            return objDto;
        }
    }
}
