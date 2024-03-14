using PruebaTecnica.Core.Application.Contracts;
using PruebaTecnica.Shared.Dtos;
using PruebaTecnica.Shared.RequestModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnica.Core.Application.Features.Activities.Queries
{
    public class ListActivitiesByGoalIdQuerys : PaginationRequestModel,IQuery<PaginationResponseModel<ActivityDto>>
    {
        public int GoalId { get; set; }
    }
}
