using System.ComponentModel.DataAnnotations;

namespace Assignment1.Models
{
    public class Media
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 1)]
        public string Title { get; set; }

        [Required]
        [Range(1, 55800, ErrorMessage = "{0} cannot be negative and must be between {2} and {1}.")]
        //550800 was set as the maxlimit because that is the longest podcast on spotify.
        public int Duration { get; set; }
        public int MediaCollectId { get; set; }
    }


    public class Songs : Media
    {
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

    public class Episodes : Media
    {
        public int PodcastId { get; set; }
        public Podcast Podcast { get; set; }

        [Display(Name = "Guest Artist")]
        public Artist? GuestArtist { get; set; }

        [Required]
        [Display(Name = "Air Date")]
        public DateTime AirDate { get; set; }

        public Episodes() { }

        public Episodes(string title, int duration, Podcast podcast,Artist? guestArtist, DateTime airDate)
        {
            Title = title;
            Duration = duration;
            Podcast = podcast;
            PodcastId = podcast.Id; 
            GuestArtist = guestArtist;
            AirDate = airDate;
        }
    }
}
