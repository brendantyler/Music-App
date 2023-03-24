using System.ComponentModel.DataAnnotations;

namespace Assignment1.Models
{
    public class SongArtist
    {
        public int Id { get; set; }

        public int ArtistId { get; set; }
        [Required]
        public Artist Artist { get; set; }

        public int SongId { get; set; }
        [Required]
        public Songs Song { get; set; }

        [Required]
        [StringLength(20, ErrorMessage = "{0} cannot be null or above {1} characters", MinimumLength = 1)]
        public string Role { get; set; }


        public SongArtist() { }
        public SongArtist(Artist artist, Songs song, string role)
        {
            Artist = artist;
            ArtistId = artist.Id;
            Song = song;
            SongId = song.Id;
            Role = role;
        }

    }
}
