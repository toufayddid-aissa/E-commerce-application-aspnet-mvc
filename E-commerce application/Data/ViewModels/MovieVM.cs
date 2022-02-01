using E_commerce_application.Models;
using System.ComponentModel.DataAnnotations;

namespace E_commerce_application.Data.ViewModel
{
    public class MovieVM
    {
        public int Id { get; set; }

        [Display(Name = "Name of the Movie")]
        public string? Name { get; set; }
        [Display(Name = "Description of the Movie")]
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
        [Display(Name = "list of the Actor")]
        //Relation
        public List<int>? ActorsId { get; set; }

        //cinema
        [Display(Name = "Cinema")]
        public int CinemaId { get; set; }



        // producer 
        [Display(Name = "Producer")]
        public int ProducerId { get; set; }
      
    }
}
