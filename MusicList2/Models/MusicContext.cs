using Microsoft.EntityFrameworkCore;

namespace MusicList2.Models
{
    public class MusicContext:DbContext
    {
        public MusicContext(DbContextOptions<MusicContext> options) : base(options) { }

        public DbSet<Music> Music { get; set; } = null!;
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Music>().HasData(
                new Music { MusicId = 1,
                    Title = "Song 1",
                    Artist = "Artist 1",
                    Year = 2000,
                    Rating = 4 },

                new Music { MusicId = 2,
                    Title = "Song 2",
                    Artist = "Artist 2",
                    Year = 2010,
                    Rating = 5 }
            );
        }


    }
}
