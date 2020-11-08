using System.Threading;
using System.Threading.Tasks;
using MediatR;
using ThriveNextGen.Shared.Infrastructure.Read.Query;

namespace ThriveNextGen.Shared.Infrastructure.Read
{
    public class QueryPublisher : IQueryPublisher
    {
        private readonly IMediator mediator;

        public QueryPublisher(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public Task<T> Publish<T>(
            IQuery<T> query,
            CancellationToken cancellationToken)
        {
            return mediator.Send(
                query,
                cancellationToken);
        }
    }
}