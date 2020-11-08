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
using ThriveNextGen.Shared.Infrastructure.Read.Query;

namespace ESVBible.Read.Query.Handler.EsvBible
{
    public class GetEsvBookNamesInBiblicalOrderQueryHandler 
        : IQueryHandler<GetEsvBookNamesInBiblicalOrderQuery, ICollection<GetEsvBookNamesInBiblicalOrderQueryResultDTO>>
    {
        private readonly IEsvBibleContext esvBibleContext;

        public GetEsvBookNamesInBiblicalOrderQueryHandler(
            IEsvBibleContext esvBibleContext)
        {
            this.esvBibleContext = esvBibleContext;
        }

        public async Task<ICollection<GetEsvBookNamesInBiblicalOrderQueryResultDTO>> Handle(
            GetEsvBookNamesInBiblicalOrderQuery request,
            CancellationToken cancellationToken)
        {
            var esvBooks = await RetrieveAllEsvBooks(cancellationToken);
            var mappedEsvBooks = esvBooks
                .Select(x => x.ToBiblicalOrderResultDTO())
                .ToList();

            return mappedEsvBooks;
        }

        private async Task<ICollection<EsvBook>> RetrieveAllEsvBooks(
            CancellationToken cancellationToken)
        {
            var allEsvBooks = await esvBibleContext.Books
                .Include(x => x.Chapters)
                .ToListAsync(cancellationToken);

            return allEsvBooks;
        }
    }
}