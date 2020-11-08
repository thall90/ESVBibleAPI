using System.Collections.Generic;

namespace ESVBible.Shared.Data.Models.EsvBible
{
#pragma warning disable 8618
    public class EsvBook
    {
        public int Id { get; set; }
        
        public string Name { get; set; }
        
        public ICollection<EsvChapter> Chapters { get; set; }
#pragma warning restore 8618
    }
}