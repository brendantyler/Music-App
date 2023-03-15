using System.Security.Policy;

namespace Assignment1.Models

{
    public class Albums
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public HashSet<Songs> Songs { get; set; }

        public Albums (string title)
        {
            Title = title;
        }

    }
}
