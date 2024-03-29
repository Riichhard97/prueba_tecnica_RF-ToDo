﻿using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PruebaTecnica.Core.Application.Contracts;
using PruebaTecnica.Core.Persistence;
using PruebaTecnica.Shared.Dtos;
using PruebaTecnica.Shared.RequestModels;

namespace PruebaTecnica.Core.Application.Features.Goals.Queries
{
    public class ListAllGoalQueryHandler : IQueryHandler<ListAllGoalQuery, PaginationResponseModel<GoalDto>>
    {
        private readonly CoreDbContext _context;
        private readonly IMapper _mapper;
        public ListAllGoalQueryHandler(CoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<PaginationResponseModel<GoalDto>> Handle(ListAllGoalQuery request, CancellationToken cancellationToken)
        {
            var totalItems = await _context.Goal.CountAsync();

            var items = await _context.Goal
                .Include(goal => goal.Activities)
                .OrderBy(i => i.Id)
                .Skip((request.Page - 1) * request.PageSize)
                .Take(request.PageSize)
                .ToListAsync();

            var itemsDto = _mapper.Map<List<GoalDto>>(items);

            var totalPages = (int)Math.Ceiling((double)totalItems / request.PageSize);

            var pagination = new PaginationResponseModel<GoalDto>
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
