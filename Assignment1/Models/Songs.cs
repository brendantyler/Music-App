using System.ComponentModel.DataAnnotations;
using System.Security.Policy;

namespace Assignment1.Models
{
    public class Songs
    {
        public int Id { get; set; }

        [Required]
        [StringLength(20, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 1)]
        public string Title { get; set; }

        [Required]
        [StringLength(550800, ErrorMessage = "{0} cannot be negative and must be between {2} and {1}.", MinimumLength = 1)]
        //550800 was set as the maxlimit because that is the longest podcast on spotify.
        public int Duration { get; set; }

        [Required]
        public Albums Albums { get; set; }

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
