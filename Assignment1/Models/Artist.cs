using System.ComponentModel.DataAnnotations;

namespace Assignment1.Models
{
    public class Artist
    {
        public int Id { get; set; }

        [Required]
        [StringLength(30, ErrorMessage = "{0} cannot be null or above {1} characters", MinimumLength = 1)]
        public string Name { get; set; }

        public HashSet<SongArtist> SongArtists { get; set; } = new HashSet<SongArtist>();

        public HashSet<PodcastAuth> PodcastAuths { get; set; } = new HashSet<PodcastAuth>();


        public Artist(string name)
        {
            Name = name;
        }

        public Artist() { }
    }
}
