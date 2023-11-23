using XYZHotelsApp.Contexts;
using XYZHotelsApp.Interfaces;
using XYZHotelsApp.Models;

namespace XYZHotelsApp.Repositories
{
    public class ReservationRepository : IRepository<int, Reservation>
    {
        private readonly XYZHotelsDBContext _context;

        public ReservationRepository(XYZHotelsDBContext context)
        {
            _context = context;
        }

        public Reservation Add(Reservation reservation)
        {
            _context.Add(reservation);
            _context.SaveChanges();
            return reservation;
        }

        public Reservation Delete(int key)
        {
            throw new NotImplementedException();
        }

        public IList<Reservation> GetAll()
        {
            throw new NotImplementedException();
        }

        public Reservation GetById(int key)
        {
            throw new NotImplementedException();
        }

        public Reservation Update(Reservation entity)
        {
            throw new NotImplementedException();
        }
    }
}
