using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnica.Core.Application.Features.Activities.Commands
{
    public class DeleteActivitiesCommand : IRequest<Unit>
    {
        public List<int> Ids { get; set; }
    }
}
