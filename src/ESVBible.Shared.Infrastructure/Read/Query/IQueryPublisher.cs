using System.Threading;
using System.Threading.Tasks;

namespace ThriveNextGen.Shared.Infrastructure.Read.Query
{
    public interface IQueryPublisher
    {
        Task<T> Publish<T>(IQuery<T> query, CancellationToken cancellationToken);
    }
}