using E_commerce_application.Data.Base;
using E_commerce_application.Data.ViewModel;
using E_commerce_application.Data.ViewModels;
using E_commerce_application.Models;

namespace E_commerce_application.Data.Services
{
    public interface IMovieService: IEntityBaseRepesotry<Movie>
    {
       Task <Movie> GetByIdAsync(int id);
        Task<NewDropDownVM> NewDropDownVM();
        Task AddMovies(MovieVM data);
        Task UpdateMovieAsync(int Id, MovieVM movie);
        Task<Movie> GetByNameAsync(string Name);


    }
}
