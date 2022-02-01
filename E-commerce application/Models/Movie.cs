using E_commerce_application.Data;
using E_commerce_application.Data.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_commerce_application.Models
{
    public class Movie:IEntityBase
    {
        [Key]
        public int Id { get; set; }    
        [Display(Name = "Name of the Movie")]
        public string? Name { get; set; }
        [Display(Description = "Description of the Movie")]
        public string? Description { get; set; }
        [Display(Name = "Price of the Movie")]
        public double Price { get; set; }
        [Display(Name = "ImageURL of the Movie")]
        public string? ImageURL { get; set; }
        [Display(Name = "start date of the Movie")]
        public DateTime? StartDate { get; set; }
        [Display(Name = "End Date of the Movie")]
        public DateTime? EndDate { get; set; }
        [Display(Name = "MovieCategorie of the Movie")]
        public MovieCategorie? MovieCategorie { get; set; }
        //Relation
        public List<Actor_Movie>? Actors_Movies { get; set; }

        //cinema

        public int CinemaId { get; set; }  
        [ForeignKey("CinemaId")]
        public Cinema? Cinema { get; set; }

        // producer 
        public int ProducerId { get; set; } 
        public Producer? Producer { get; set; }

    }
}
