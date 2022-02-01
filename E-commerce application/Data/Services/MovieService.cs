using E_commerce_application.Data.Base;
using E_commerce_application.Data.ViewModel;
using E_commerce_application.Data.ViewModels;
using E_commerce_application.Models;
using Microsoft.EntityFrameworkCore;


namespace E_commerce_application.Data.Services
{
    public class MovieService :EntityBaseRepesotry<Movie>, IMovieService 
    {


        private AddDbContext _context;
        public MovieService(AddDbContext context) : base(context) {
            _context = context;
        }

        public async Task AddMovies(MovieVM data)
        {
            var NewMovie = new Movie()
            {
                Name = data.Name,
                Price = data.Price,
                ImageURL = data.ImageURL,
                ProducerId = data.ProducerId,
                CinemaId = data.CinemaId,
                Description = data.Description,
                StartDate = data.StartDate,
                EndDate = data.EndDate,
                MovieCategorie = data.MovieCategorie

            };
             await _context.Movies.AddAsync(NewMovie);
            await _context.SaveChangesAsync();


            // add actor Movie
            foreach(var actorId in data.ActorsId)
            {
                var movie_actor = new Actor_Movie()
                {
                    MovieID = NewMovie.Id,
                    ActorID = actorId
                };
                await _context.Actors_Movies.AddAsync(movie_actor);
                await _context.SaveChangesAsync();  
            }
            
        }

        

        public async Task<Movie> GetByIdAsync(int id)
        {
            var movie = _context.Movies
                .Include(c => c.Cinema)
                .Include(p => p.Producer)
                .Include(mc => mc.Actors_Movies).ThenInclude(a => a.Actor).FirstOrDefaultAsync(m => m.Id == id);
            return await movie;
        }

        public Task<Movie> GetByNameAsync(string Name)
        {
            var movie = _context.Movies.FirstOrDefaultAsync(n => n.Name == Name);
            return movie;
        }

        //get all data and affiche all in list
        public async Task<NewDropDownVM> NewDropDownVM()
        {
            var response = new NewDropDownVM()
            {
                Actors = await _context.Actors.OrderBy(n => n.FullName).ToListAsync(),
                Producers = await _context.Producers.OrderBy(n => n.FullName).ToListAsync(),
                Cinemas = await _context.Cinemas.OrderBy(n => n.Name).ToListAsync()
            };
            return response;
        }

        public async Task UpdateMovieAsync(int Id, MovieVM data)
        {
            var DbMovie = await _context.Movies.FirstOrDefaultAsync(e => e.Id == data.Id);
            var x = 0;
            if (DbMovie != null)
            {
                DbMovie.Name = data.Name;
                DbMovie.Price = data.Price;
                DbMovie.ImageURL = data.ImageURL;
                DbMovie.ProducerId = data.ProducerId;
                DbMovie.CinemaId = data.CinemaId;
                DbMovie.Description = data.Description;
                DbMovie.StartDate = data.StartDate;
                DbMovie.EndDate = data.EndDate;
                DbMovie.MovieCategorie = data.MovieCategorie;
                await _context.SaveChangesAsync();
            }

            //Remove existing  Actors
            var OldActor =  _context.Actors_Movies.Where(n => n.MovieID == data.Id).ToList();
            _context.Actors_Movies.RemoveRange(OldActor);
            await _context.SaveChangesAsync();









            // add actor Movie
            foreach (var actorId in data.ActorsId)
            {
                var movie_actor = new Actor_Movie()
                {
                    MovieID = data.Id,
                    ActorID = actorId
                };
                await _context.Actors_Movies.AddAsync(movie_actor);
                await _context.SaveChangesAsync();
            }
        }
    }
}
