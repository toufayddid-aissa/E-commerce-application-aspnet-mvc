using E_commerce_application.Data.Base;
using System.ComponentModel.DataAnnotations;

namespace E_commerce_application.Models
{
    public class Actor : IEntityBase
    {
        [Key]
        public int? Id { get; set; } 
        
        [Display(Name ="Profile Picture")]
        [Required(ErrorMessage ="profile is required")]
        public string? ProfilePictureURL { get; set; }
        
        [Display(Name = "Actor Name")]
        [Required(ErrorMessage = "Name is required")]
        
        public string? FullName { get; set;}
        [Required(ErrorMessage = "Biograpgie is required")]
        [Display(Name = "Biograpgie")]
        public string? Bio { get; set;}
        //Relation
        public List<Actor_Movie>? Actors_Movies { get; set;}
        int IEntityBase.Id { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
