using Microsoft.AspNetCore.Mvc.Rendering;
using System.Net;

namespace Assignment1.Models.ViewModels
{
    public class AddSongToPlaylistViewModel
    {
        public Songs Song { get; set; } 
        public HashSet<SelectListItem> Playlists { get; set; } = new HashSet<SelectListItem>();

        public int? SongId { get; set; }
        public int? PlaylistId { get; set; }

        public void PopulateList(Songs song, IEnumerable<Playlist> playlists)
        {
            Song = song;
            SongId = song.Id;
            foreach (Playlist p in playlists)
            {
                Playlists.Add(new SelectListItem($"{p.Name})", p.Id.ToString()));
            }
        }

        // Interface parameters can take ANY child of parameter type as argument
        public AddSongToPlaylistViewModel(Songs song, IEnumerable<Playlist> playlist)
        {
            Song = song;
            PopulateList(song, playlist);
        }

        public AddSongToPlaylistViewModel()
        {

        }
    }
}
