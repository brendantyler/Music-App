using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Assignment1.Models;

namespace Assignment1.Data
{
    public class Assignment1Context : DbContext
    {
        public Assignment1Context (DbContextOptions<Assignment1Context> options)
            : base(options)
        {
        }

        public DbSet<Assignment1.Models.Artist> Artists { get; set; } = default!;
        public DbSet<Assignment1.Models.Albums> Albums { get; set; } = default!;
        public DbSet<Assignment1.Models.Songs> Songs { get; set; } = default!;
        public DbSet<Assignment1.Models.SongArtist> SongArtists { get; set; } = default!;
        public DbSet<Assignment1.Models.Playlist> Playlists { get; set; } = default!;
        public DbSet<Assignment1.Models.PlaylistSong> PlaylistSongs { get; set; } = default!;

    }
}
