using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IceCreamCart.Models
{
    [Table("Page")]
    public class Page
    {
        [Key]
        public int Id { get; set; }
        [Required,MinLength(4,ErrorMessage ="Minimum length is 4 charecters")]
        public string? Title { get; set; }
        //Slug = url of the page
        public string? Slug { get; set; }
        [Required,MinLength(4, ErrorMessage = "Minimum length is 4 charecters")]
        public string? Context { get; set; }
        public int Sorting { get; set; }
    }
}
