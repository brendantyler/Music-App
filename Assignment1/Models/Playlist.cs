using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;

namespace Assignment1.Models
{
    public class Playlist
    {
        public int Id { get; set; }

        [Required]
        [StringLength(20, ErrorMessage = "{0} cannot be null or above {1} characters", MinimumLength = 1)]
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
