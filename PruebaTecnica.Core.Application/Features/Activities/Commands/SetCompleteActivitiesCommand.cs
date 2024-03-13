using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnica.Core.Application.Features.Activities.Commands
{
    public class SetCompleteActivitiesCommand : IRequest<Unit>
    {
        public List<int> Ids { get; set; }
        public bool isComplete { get; set; }
    }
}
