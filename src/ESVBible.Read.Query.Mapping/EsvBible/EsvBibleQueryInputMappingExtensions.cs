using ESVBible.Read.Query.EsvBible;
using ESVBible.Read.Query.Transport.EsvBible.Input;

namespace ThriveNextGen.Read.Query.Mapping.EsvBible
{
    public static class EsvBibleQueryInputMappingExtensions
    {
        public static GetEsvBookNamesInAlphabeticalOrderQuery ToQuery(
            this GetEsvBookNamesInAlphabeticalOrderInputDTO inputDTO)
        {
            return new GetEsvBookNamesInAlphabeticalOrderQuery(inputDTO.SortDirection);
        }
    }
}