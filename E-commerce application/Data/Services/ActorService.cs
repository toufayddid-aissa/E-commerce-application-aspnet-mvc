using E_commerce_application.Data.Base;
using E_commerce_application.Models;

namespace E_commerce_application.Data.Services
{
    public class ActorService :EntityBaseRepesotry<Actor>, IActorsService
    {
        
        public ActorService(AddDbContext context) : base(context) { }
        
    }
}
