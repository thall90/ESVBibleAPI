using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ESVBible.Read.Query.EsvBible;
using ESVBible.Read.Query.Transport.EsvBible.Result;
using Microsoft.EntityFrameworkCore;
using ThriveNextGen.Read.Query.Mapping.EsvBible;
using ESVBible.Shared.Data.Contexts;
using ESVBible.Shared.Data.Models.EsvBible;
using ThriveNextGen.Shared.Infrastructure.Extensions;
using ThriveNextGen.Shared.Infrastructure.Read.Query;

namespace ESVBible.Read.Query.Handler.EsvBible
{
    public class GetEsvBookNamesInAlphabeticalOrderQueryHandler 
        : IQueryHandler<GetEsvBookNamesInAlphabeticalOrderQuery, ICollection<GetEsvBookNamesInAlphabeticalOrderQueryResultDTO>>
    {
        private readonly IEsvBibleContext esvBibleContext;

        public GetEsvBookNamesInAlphabeticalOrderQueryHandler(
            IEsvBibleContext esvBibleContext)
        {
            this.esvBibleContext = esvBibleContext;
        }

        public async Task<ICollection<GetEsvBookNamesInAlphabeticalOrderQueryResultDTO>> Handle(
            GetEsvBookNamesInAlphabeticalOrderQuery request,
            CancellationToken cancellationToken)
        {
            var esvBooks = await RetrieveAllEsvBooks(request, cancellationToken);
            var mappedEsvBooks = esvBooks
                .Select(x => x.ToABCOrderResultDTO())
                .ToList();

            return mappedEsvBooks;
        }

        private async Task<ICollection<EsvBook>> RetrieveAllEsvBooks(
            GetEsvBookNamesInAlphabeticalOrderQuery query,
            CancellationToken cancellationToken)
        {
            var allEsvBooks = await esvBibleContext.Books
                .Include(x => x.Chapters)
                .SortBy(x => x.Name, query.SortDirection)
                .ToListAsync(cancellationToken);

            return allEsvBooks;
        }
    }
}