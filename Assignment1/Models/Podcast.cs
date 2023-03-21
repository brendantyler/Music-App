namespace Assignment1.Models
{
    public class Podcast
    {
        public int Id { get; set; }
        public string Name { get; set; }
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
