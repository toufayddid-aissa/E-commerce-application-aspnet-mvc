using E_commerce_application.Models;

namespace E_commerce_application.Data.Services
{
    public class ProducerService : IProducersService
    {
        private AddDbContext _context;
        public ProducerService(AddDbContext context)
        {
            _context = context;

        }
        public void Add(Producer producer)
        {
            _context.Producers.Add(producer);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var data = _context.Producers.FirstOrDefault(e => e.Id == id);
            _context.Producers.Remove(data);
            _context.SaveChanges();
        }

        public IEnumerable<Producer> GetAll()
        {
            var result = _context.Producers.ToList();
            return result;
        }

        public Producer GetById(int id)
        {
            var data = _context.Producers.FirstOrDefault(e => e.Id == id);
            return data;
        }

        public Producer Update(int id, Producer NewActor)
        {
            _context.Producers.Update(NewActor);
            _context.SaveChanges();
            return NewActor;
        }
    }
}
