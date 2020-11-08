using System.Collections.Generic;

namespace ESVBible.Shared.Data.Models.EsvBible
{
    public class EsvBook
    {
#pragma warning disable 8618
        public int Id { get; set; }
        
        public string Name { get; set; }
        
        public ICollection<EsvChapter> Chapters { get; set; }
#pragma warning restore 8618
    }
}