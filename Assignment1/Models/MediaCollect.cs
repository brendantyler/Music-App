using System.ComponentModel.DataAnnotations;

namespace Assignment1.Models
{
    public class MediaCollect
    {
        public int Id { get; set; }

        [Required]
        [StringLength(40, ErrorMessage = "{0} cannot be null or above {1} characters", MinimumLength = 1)]
        public string Name { get; set; }
    }

    public class Albums : MediaCollect
    {
        public HashSet<Songs> Songs { get; set; }

        public Albums() { }
        public Albums(string name)
        {
            Name = name;
        }
    }

    public class Playlist : MediaCollect
    {
        public HashSet<PlaylistSong> PlaylistSong { get; set; } = new HashSet<PlaylistSong>();
        public Playlist() { }
        public Playlist(string name)
        {
            Name = name;
        }
    }

    public class ListenerLists : MediaCollect
    {
        public HashSet<PodcastListenerLists> PodcastListenerLists = new HashSet<PodcastListenerLists>();

        public ListenerLists() { }
        public ListenerLists(string name)
        {
            Name = name;
        }
    }
    public class Podcast : MediaCollect
    {
        public string Description { get; set; }
        HashSet<Episodes> Episodes { get; set; } = new HashSet<Episodes>();
        public Podcast(string name, string desc)
        {
            Name = name;
            Description = desc;
        }

        public Podcast() { }
    }
}
