using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnica.Core.Application.Features.Activities.Commands
{
    public class AddActivityCommand : IRequest<Unit>
    {
        public int GoalId { get; set; }
        public string Name { get; set; }
    }
}
