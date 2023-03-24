using Microsoft.AspNetCore.Mvc.Rendering;
using System.Net;

namespace Assignment1.Models.ViewModels
{
    public class PodcastToListViewModel
    {
        public Podcast Podcast { get; set; }
        public HashSet<SelectListItem> ListenerListsColl { get; set; } = new HashSet<SelectListItem>();

        public int? PodcastId { get; set; }
        public int? ListenerListsId { get; set; }

        public void PopulateList(Podcast podcast, IEnumerable<ListenerLists> lists)
        {
            Podcast = podcast;
            PodcastId = podcast.Id;
            foreach (ListenerLists list in lists)
            {
                ListenerListsColl.Add(new SelectListItem($"{list.Name})", list.Id.ToString()));
            }
        }

        // Interface parameters can take ANY child of parameter type as argument
        public PodcastToListViewModel (Podcast p, IEnumerable<ListenerLists> list)
        {
            Podcast = p;
            PopulateList(p, list);
        }

        public PodcastToListViewModel()
        {

        }
    }
}
