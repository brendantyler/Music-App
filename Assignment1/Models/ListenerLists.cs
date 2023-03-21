namespace Assignment1.Models
{
    public class ListenerLists : Playlist
    {
        public ListenerLists(string name) { }

        public HashSet<PodcastListenerLists> PodcastListenerLists = new HashSet<PodcastListenerLists>();

    }
}
