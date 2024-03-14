using PruebaTecnica.Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnica.Shared.RequestModels.Acitivity
{
    public class ListActivitiesByGoalRequestModel : PaginationRequestModel
    {
        public int GoalId { get; set; }
    }
}
