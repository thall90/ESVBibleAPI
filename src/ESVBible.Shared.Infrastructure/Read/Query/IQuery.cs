using MediatR;

namespace ThriveNextGen.Shared.Infrastructure.Read.Query
{
    public interface IQuery<out T> : IRequest<T>
    {
    }
}