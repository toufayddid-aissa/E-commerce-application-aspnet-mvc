using E_commerce_application.Models;

namespace E_commerce_application.Data.Services
{
    public interface IProducersService
    {
        IEnumerable<Producer> GetAll();
        Producer GetById(int id);
        void Add(Producer producer);

        Producer Update(int id, Producer NewActor);
        void Delete(int id);
    }
}
