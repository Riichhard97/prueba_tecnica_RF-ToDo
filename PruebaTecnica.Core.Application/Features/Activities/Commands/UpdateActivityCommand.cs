using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnica.Core.Application.Features.Activities.Commands
{
    public class UpdateActivityCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public bool? Important { get; set; }
    }
}
