using E_commerce_application.Data.Base;
using E_commerce_application.Models;

namespace E_commerce_application.Data.Services
{
    public class CinemaService : EntityBaseRepesotry<Cinema> , ICinemaService
    {
        public CinemaService(AddDbContext context) : base(context) { }
    }
}
