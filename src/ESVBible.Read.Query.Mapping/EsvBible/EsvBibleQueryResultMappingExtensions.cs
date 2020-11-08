using ESVBible.Read.Query.Transport.EsvBible.Result;
using ESVBible.Shared.Data.Models.EsvBible;

namespace ThriveNextGen.Read.Query.Mapping.EsvBible
{
    public static class EsvBibleQueryResultMappingExtensions
    {
        public static GetEsvBookNamesInBiblicalOrderQueryResultDTO ToBiblicalOrderResultDTO(
            this EsvBook esvBook)
        {
            return new GetEsvBookNamesInBiblicalOrderQueryResultDTO(
                esvBook.Id,
                esvBook.Name,
                esvBook.Chapters.Count);
        }
        
        public static GetEsvBookNamesInAlphabeticalOrderQueryResultDTO ToABCOrderResultDTO(
            this EsvBook esvBook)
        {
            return new GetEsvBookNamesInAlphabeticalOrderQueryResultDTO(
                esvBook.Id,
                esvBook.Name,
                esvBook.Chapters.Count);
        }
    }
}