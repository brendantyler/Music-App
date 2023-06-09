﻿namespace Assignment1.Models
{
    public class SongArtist
    {
        public int Id { get; set; }
        public int ArtistId { get; set; }
        public Artist? Artist { get; set; }
        public int SongId { get; set; }
        public Songs? Song { get; set; }

        public string? Role { get; set; }

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
