using System.Collections.Generic;

namespace ESVBible.Shared.Data.Models.EsvBible
{
    public class EsvBook
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<EsvChapter> Chapters { get; set; }
    }
}