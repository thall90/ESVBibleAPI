namespace ESVBible.Read.Query.Transport.EsvBible.Result
{
    public class GetEsvBookNamesInBiblicalOrderQueryResultDTO
    {
        public int Id { get; private set; }

        public string Name { get; private set; }

        public int NumberOfChapters { get; private set; }

        public GetEsvBookNamesInBiblicalOrderQueryResultDTO(
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