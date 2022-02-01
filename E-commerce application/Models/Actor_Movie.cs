namespace E_commerce_application.Models
{
    public class Actor_Movie
    {
        public int ActorID { get; set; }   
        public Actor Actor { get; set; }
        public int MovieID { get; set; }    
        public Movie Movie { get; set; }
    }
}
