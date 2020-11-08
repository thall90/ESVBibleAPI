using ESVBible.Shared.Data.Models.EsvBible;
using Microsoft.EntityFrameworkCore;

namespace ESVBible.Shared.Data.Contexts
{
    public interface IEsvBibleContext: IDbContext
    {
        DbSet<EsvBook> Books { get; set; }
        
        DbSet<EsvChapter> Chapters { get; set; }
        
        DbSet<EsvVerse> Verses { get; set; }
    }
}