using MediatR;

namespace ThriveNextGen.Shared.Infrastructure.Read.Query
{
    public interface IQueryHandler<in TQuery, TResponse> : IRequestHandler<TQuery, TResponse>
        where TQuery : IQuery<TResponse>
    {
    }
}