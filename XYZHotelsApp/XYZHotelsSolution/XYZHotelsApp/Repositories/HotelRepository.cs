using XYZHotelsApp.Contexts;
using XYZHotelsApp.Interfaces;
using XYZHotelsApp.Models;

namespace XYZHotelsApp.Repositories
{
    public class HotelRepository : IRepository<int, Hotel>
    {
        private readonly XYZHotelsDBContext _context;

        public HotelRepository(XYZHotelsDBContext context)
        {
            _context = context;
        }

        public Hotel Add(Hotel hotel)
        {
            _context.Hotels.Add(hotel);
            _context.SaveChanges();
            return hotel;
        }


        public Hotel Delete(int key)
        {
            var hotel = GetById(key);
            if (hotel != null)
            {
                _context.Hotels.Remove(hotel);
                _context.SaveChanges();
                return hotel;
            }
            return null;
        }

        public IList<Hotel> GetAll()
        {
            if (_context.Hotels.Count() == 0)
                return null;
            return _context.Hotels.ToList();
        }

        public Hotel GetById(int key)
        {
            var hotel = _context.Hotels.SingleOrDefault(b => b.HotelId == key);
            return hotel;
        }

        public Hotel Update(Hotel entity)
        {
            throw new NotImplementedException();
        }
    }
}