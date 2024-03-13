using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnica.Core.Application.Contracts
{
    public interface IQuery<out T> : IRequest<T>
    {
    }
}
