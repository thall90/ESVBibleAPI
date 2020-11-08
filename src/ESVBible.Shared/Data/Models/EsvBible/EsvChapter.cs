using System.Collections.Generic;

namespace ESVBible.Shared.Data.Models.EsvBible
{
#pragma warning disable 8618
    public class EsvChapter
    {
        public int Id { get; set; }
        
        public int Number { get; set; }

        public int EsvBookId { get; set; }

        public ICollection<EsvVerse> Verses { get; set; } = null!;
    }
#pragma warning restore 8618
}