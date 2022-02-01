using System.ComponentModel.DataAnnotations;

namespace E_commerce_application.Models
{
    public class Producer
    {
        [Key]
        public int Id { get; set; }
        [Display(Name =" Producer Profile")]
        public string? ProfilePictureURL { get; set; }
        [Display(Name = " Producer Name")]
        public string? FullName { get; set; }
        [Display(Name = " Producer Bio")]
        public string? Bio { get; set; }
        // Relation between other Database
        public List<Movie>? Movies { get; set; }
    }
}
