﻿using PruebaTecnica.Core.Application.Contracts;
using PruebaTecnica.Shared.Dtos;
using PruebaTecnica.Shared.RequestModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnica.Core.Application.Features.Goals.Queries
{
    public class ListAllGoalQuery : PaginationRequestModel, IQuery<PaginationResponseModel<GoalDto>>
    {
    }
}
