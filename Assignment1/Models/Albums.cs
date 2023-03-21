using System.ComponentModel.DataAnnotations;
using System.Security.Policy;

namespace Assignment1.Models

{
    public class Albums
    {
        public int Id { get; set; }

        [Required]
        [StringLength(8, ErrorMessage = "{0} cannot be null or above {1} characters", MinimumLength = 1)]
        public string Title { get; set; }
        public HashSet<Songs> Songs { get; set; }

        public Albums (string title)
        {
            Title = title;
        }

    }
}
