using ESVBible.Shared.Data.Contexts;
using ESVBible.Shared.Data.Models.EsvBible;
using Microsoft.EntityFrameworkCore;

namespace ESVBible.Data.Contexts
{
#pragma warning disable 8618
    public class EsvBibleContext : DbContext, IEsvBibleContext
    {
        private const string schema = "EsvBible";
        
        public EsvBibleContext(DbContextOptions<EsvBibleContext> options)
            : base(options)
        {
        }
        
        public DbSet<EsvBook> Books { get; set; } = null!;

        public DbSet<EsvChapter> Chapters { get; set; } = null!;

        public DbSet<EsvVerse> Verses { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasSequence($"\"{schema}\".\"Book_Id_seq\"");
            modelBuilder.HasSequence($"\"{schema}\".\"Chapter_Id_seq\"");
            modelBuilder.HasSequence($"\"{schema}\".\"Verse_Id_seq\"");
            
            modelBuilder.Entity<EsvBook>(book =>
            {
                book.ToTable("Book", schema);
                book.HasKey(u => u.Id);
                book.HasMany(x => x.Chapters);
                book.Property(u => u.Id)
                    .ValueGeneratedOnAdd()
                    .HasDefaultValueSql($"nextval('\"{schema}\".\"Book_Id_seq\"'::regclass)");
            });

            modelBuilder.Entity<EsvChapter>(chapter =>
            {
                chapter.ToTable("Chapter", schema);
                chapter.HasKey(x => x.Id);
                chapter.HasMany(x => x.Verses);
                chapter.Property(u => u.Id)
                    .ValueGeneratedOnAdd()
                    .HasDefaultValueSql($"nextval('\"{schema}\".\"Chapter_Id_seq\"'::regclass)");
            });
            
            modelBuilder.Entity<EsvVerse>(verse =>
            {
                verse.ToTable("Verse", schema);
                verse.HasKey(x => x.Id);
                verse.Property(u => u.Id)
                    .ValueGeneratedOnAdd()
                    .HasDefaultValueSql($"nextval('\"{schema}\".\"Verse_Id_seq\"'::regclass)");
            });
        }
    }
#pragma warning restore 8618
}