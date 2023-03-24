using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Assignment1.Models
{
    public class PodcastAuth
    {
        public int Id { get; set; }

        public int PodcastId { get; set; }
        [Required]
        public Podcast Podcast { get; set; }

        public int ArtistId { get; set; }
        [Required]
        public Artist Artist { get; set; }

        public PodcastAuth() { }
        public PodcastAuth(Podcast podcast, Artist artist)
        { 
            PodcastId = podcast.Id;
            Podcast = podcast;

            ArtistId = artist.Id;
            Artist = artist;
        }
    }
}
