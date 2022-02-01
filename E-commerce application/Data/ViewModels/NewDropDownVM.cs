using E_commerce_application.Models;

namespace E_commerce_application.Data.ViewModels
{
    public class NewDropDownVM
    {
        public NewDropDownVM()
        {
            Producers = new List<Producer>();
            Actors = new List<Actor>();
            Cinemas = new List<Cinema>() ;

        }
        public List<Producer> Producers { get; set; }   
        public List<Actor> Actors { get; set; }
        public List<Cinema> Cinemas { get; set; }    
    }
}
