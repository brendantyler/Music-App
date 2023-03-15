namespace Assignment1.Models
{
    public class PlaylistSong
    {
        public int Id { get; set; }
        public int SongId { get; set; }
        public Songs? Song { get; set; }
        public int PlaylistId { get; set; }
        public Playlist? Playlist { get; set; }
        public DateTime TimeAdded { get; set; }

        public PlaylistSong () { }

        public PlaylistSong (Songs song, Playlist playlist)
        { 
            Song = song;
            SongId = song.Id;

            Playlist = playlist;
            PlaylistId = playlist.Id;

            TimeAdded = DateTime.UtcNow;
        }
    }
}

