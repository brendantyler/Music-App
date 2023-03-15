namespace Assignment1.Models
{
    public class Artist
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public HashSet<SongArtist> SongArtists { get; set; } = new HashSet<SongArtist>();

        public Artist(string name)
        {
            Name = name;
        }

        public Artist() { }
    }
}
