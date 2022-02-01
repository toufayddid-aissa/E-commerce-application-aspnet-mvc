using E_commerce_application.Data.Base;
using System.ComponentModel.DataAnnotations;

namespace E_commerce_application.Models
{
    public class Cinema : IEntityBase
    {
        [Key]
        public int Id { get; set; } 
        [Display(Name ="Name of Cinema")]
        public string? Name { get; set; }
        [Display(Name = "Logo of Cinema")]

        public string? Logo { get; set; }
        [Display(Name = "Description of Cinema")]

        public string? Description { get; set; }
        // relation between other database
        public List<Movie>? Movies { get; set; } 
    }
}
