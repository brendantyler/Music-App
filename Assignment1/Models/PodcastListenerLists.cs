using System.ComponentModel.DataAnnotations;

namespace Assignment1.Models
{
    public class PodcastListenerLists
    {
        public int Id { get; set; }
        public int PodcastId { get; set; }

        [Required]
        public Podcast? Podcast { get; set; }
        public int ListenerListId { get; set; }

        [Required]
        public ListenerLists? ListenerList { get; set; }


        public DateTime TimeAdded { get; set; }

        public PodcastListenerLists() { }

        public PodcastListenerLists(Podcast? podcast, ListenerLists? listenerList, DateTime timeAdded)
        {
            PodcastId = podcast.Id;
            Podcast = podcast;
            ListenerListId = listenerList.Id;
            ListenerList = listenerList;
            TimeAdded = timeAdded;
        }

       
    }
}
