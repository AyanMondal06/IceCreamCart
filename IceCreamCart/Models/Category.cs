using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IceCreamCart.Models
{
    [Table("Category")]
    public class Category
    {
        
        [Key]
        public int Id { get; set; }
        [Required,MinLength(4,ErrorMessage ="Minimum length is 4")]
        [RegularExpression(@"^[a-zA-Z]+$",ErrorMessage ="Only Leters are allowed")]
        public String? Name{ get; set; }
        [Required]
        public String? Slug { get; set; }
        public int Sorting { get; set; }
        


    }
}
