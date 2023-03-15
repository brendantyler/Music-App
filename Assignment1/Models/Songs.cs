using System.Security.Policy;

namespace Assignment1.Models
{
    public class Songs
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public int Duration { get; set; }
        public Albums? Albums { get; set; }

        public HashSet<PlaylistSong>? PlaylistSong { get; set; } = new HashSet<PlaylistSong>();
        public HashSet<SongArtist> SongArtists { get; set; } = new HashSet<SongArtist>();
        public Songs() { }
        public Songs(string title, int duration, Albums album)
        {
            Title = title;
            Duration = duration;
            Albums = album;  
        }

    }
}
