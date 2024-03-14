using AutoMapper;
using Azure;
using Microsoft.EntityFrameworkCore;
using PruebaTecnica.Core.Application.Contracts;
using PruebaTecnica.Core.Persistence;
using PruebaTecnica.Shared.Dtos;
using PruebaTecnica.Shared.RequestModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnica.Core.Application.Features.Activities.Queries
{
    public class ListActivitiesByGoalIdQuerysHandler : IQueryHandler<ListActivitiesByGoalIdQuerys, PaginationResponseModel<ActivityDto>>
    {
        private readonly CoreDbContext _context;
        private readonly IMapper _mapper;
        public ListActivitiesByGoalIdQuerysHandler(CoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<PaginationResponseModel<ActivityDto>> Handle(ListActivitiesByGoalIdQuerys request, CancellationToken cancellationToken)
        {
            var totalItems = await _context.Activity.Where(activity=>activity.GoalId == request.GoalId).CountAsync();

            var items = await _context.Activity
                .Where(activity => activity.GoalId == request.GoalId)
                .OrderBy(i => i.Id)
                .Skip((request.Page - 1) * request.PageSize)
                .Take(request.PageSize)
                .ToListAsync();

            var itemsDto = _mapper.Map<List<ActivityDto>>(items);

            var totalPages = (int)Math.Ceiling((double)totalItems / request.PageSize);

            var pagination = new PaginationResponseModel<ActivityDto>
            {
                Data = itemsDto,
                Page = request.Page,
                PageSize = request.PageSize,
                TotalPages = totalPages,
                TotalItems = totalItems
            };

            return pagination;
        }
    }
}
