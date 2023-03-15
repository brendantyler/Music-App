using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.VisualBasic.Syntax;
using Microsoft.Identity.Client.Extensions.Msal;

namespace Assignment1.Models.ViewModels
{
    public class SongsInPlaylist
    {
        public HashSet<PlaylistSong> PlaylistSongs { get; set; } = new HashSet<PlaylistSong>();

        public HashSet<Songs> Songs { get; set; } = new HashSet<Songs>();
        public Playlist Playlist { get; set; }

        public int? PlaylistId { get; set; }

        public int? SongId { get; set; }

        public void PopulatePlaylistSong(Playlist playlist, IEnumerable<Songs> songs)
        {
            foreach (Songs song in songs)
            {
            }
        }

        public SongsInPlaylist(Playlist playlist, IEnumerable<Songs> songs) 
        {
            Playlist = playlist;
            PlaylistId = playlist.Id;
        }

        public SongsInPlaylist() { }
        
    }
}
