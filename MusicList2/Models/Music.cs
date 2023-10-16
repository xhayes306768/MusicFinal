using System.ComponentModel.DataAnnotations;

namespace MusicList2.Models
{
    public class Music
    {
        internal readonly object Name;

        public int MusicId { get; set; }

        [Required(ErrorMessage = "Please enter a title.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Please enter the artist.")]
        public string Artist { get; set; }

        [Required(ErrorMessage = "Please enter the year.")]
        [Range(1889, 2999, ErrorMessage = "Year must be after 1889.")]
        public int Year { get; set; }

        [Required(ErrorMessage = "Please enter a rating.")]
        [Range(1, 5, ErrorMessage = "Rating must be between 1 and 5.")]
        public int Rating { get; set; } 
    }


}

