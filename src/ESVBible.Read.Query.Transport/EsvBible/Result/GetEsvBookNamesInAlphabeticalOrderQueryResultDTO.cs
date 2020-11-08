namespace ESVBible.Read.Query.Transport.EsvBible.Result
{
    public class GetEsvBookNamesInAlphabeticalOrderQueryResultDTO
    {
        public int Id { get; private set; }

        public string Name { get; private set; }

        public int NumberOfChapters { get; private set; }

        public GetEsvBookNamesInAlphabeticalOrderQueryResultDTO(
            int id,
            string name,
            int numberOfChapters)
        {
            Id = id;
            Name = name;
            NumberOfChapters = numberOfChapters;
        }
    }
}