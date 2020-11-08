using System.Collections.Generic;
using ESVBible.Read.Query.Transport.EsvBible.Result;
using ESVBible.Shared.Enum;
using ThriveNextGen.Shared.Infrastructure.Read.Query;

namespace ESVBible.Read.Query.EsvBible
{
    public class GetEsvBookNamesInAlphabeticalOrderQuery 
        : IQuery<ICollection<GetEsvBookNamesInAlphabeticalOrderQueryResultDTO>> 
    {
        public SortDirection SortDirection { get; private set; }

        public GetEsvBookNamesInAlphabeticalOrderQuery(
            SortDirection sortDirection)
        {
            SortDirection = sortDirection;
        }
    }
}