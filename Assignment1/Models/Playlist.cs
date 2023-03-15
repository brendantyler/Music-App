using System.Diagnostics.Contracts;

namespace Assignment1.Models
{
    public class Playlist
    {
        public int Id { get; set; } 

        public string Name { get; set; }

        public HashSet<PlaylistSong> PlaylistSong { get; set; } = new HashSet<PlaylistSong>();

        public Playlist (string name)
        {
            Name = name;
        }

        public Playlist ()
        {
        }
    }
}
