namespace ESVBible.Shared.Data.Models.EsvBible
{
#pragma warning disable 8618
    public class EsvVerse
    {
        public int Id { get; set; }
        
        public int Number { get; set; }

        public int EsvChapterId { get; set; }

        public string Value { get; set; }
    }
#pragma warning disable 8618
}