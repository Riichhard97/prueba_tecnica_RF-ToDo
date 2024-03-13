using MediatR;

namespace PruebaTecnica.Core.Application.Contracts
{
    public interface IQueryHandler<in TQuery, TResult> : IRequestHandler<TQuery, TResult>
      where TQuery : IQuery<TResult>
    {
    }
}
