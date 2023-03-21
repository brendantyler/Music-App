namespace Assignment1.Models
{
    public class Episodes : Songs
    {
        public Podcast Podcast { get; set; }
        public Artist? GuestArtist { get; set; }
        public DateTime AirDate { get; set; }

        public Episodes(int id, string title, int duration, Podcast podcast, Artist? guestArtist, DateTime airDate)
        {
            Id = id;
            Title = title;
            Duration = duration;
            Podcast = podcast;
            GuestArtist = guestArtist;
            AirDate = airDate;
        }

        public Episodes() { }
    }
}
