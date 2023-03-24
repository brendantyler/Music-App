using System.ComponentModel.DataAnnotations;

namespace Assignment1.Models
{
    public class PlaylistSong
    {
        public int Id { get; set; }
        public int SongId { get; set; }

        [Required]
        public Songs? Song { get; set; }
        public int PlaylistId { get; set; }

        [Required]
        public Playlist? Playlist { get; set; }

        [Required]
        [Display(Name= "Time Added")]
        public DateTime TimeAdded { get; set; }

        public PlaylistSong () { }

        public PlaylistSong (Songs song, Playlist playlist, DateTime date)
        { 
            Song = song;
            SongId = song.Id;

            Playlist = playlist;
            PlaylistId = playlist.Id;
            TimeAdded = date;
        }
    }
}

